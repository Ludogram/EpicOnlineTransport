using System;
using Epic.OnlineServices;
using Epic.OnlineServices.Lobby;
using UnityEngine;
using Attribute = Epic.OnlineServices.Lobby.Attribute;

#if UNITY_SWITCH
using Plugins.ConsoleSpecific.Switch;
#endif

namespace EpicTransport
{
    public class LobbySetAttribute
    {
        private EosLobby _lobby;
        private readonly LobbyInterface _lobbyInterface;
        private LobbyModification _lobbyModificationHandle;

        public LobbySetAttribute(EosLobby lobby)
        {
            _lobby = lobby;
            _lobbyInterface = EOSSDKComponent.GetLobbyInterface();    
            
            UpdateLobbyModificationOptions updateLobbyModificationOptions = new()
            {
                LocalUserId = EOSSDKComponent.LocalUserProductId,
                LobbyId = _lobby.LobbyId
            };

            _lobbyInterface.UpdateLobbyModification(ref updateLobbyModificationOptions, out _lobbyModificationHandle);
        }
        
        public LobbySetAttribute SetAttribute(AttributeData data, LobbyAttributeVisibility visibility = LobbyAttributeVisibility.Public)
        {
            if (_lobbyModificationHandle == null)
            {
                Debug.LogError("Attribute already sent.");
                return null;
            }
            LobbyModificationAddAttributeOptions addAttributeOptions = new()
            {
                Attribute = data,
                Visibility = visibility
            };

            _lobbyModificationHandle.AddAttribute(ref addAttributeOptions);
            
            return this;
        }

        public void Send()
        {
            UpdateLobbyOptions updateLobbyOptions = new()
            {
                LobbyModificationHandle = _lobbyModificationHandle
            };

            _lobbyInterface.UpdateLobby(ref updateLobbyOptions, null, 
                (ref UpdateLobbyCallbackInfo info) => 
                { 
                    if (info.ResultCode != Result.Success)
                    {
                        Debug.LogError("UpdateLobby failed with " + info.ResultCode);
                    }
                    Debug.Log("UpdateLobby success");
                });
            
            _lobbyModificationHandle.Release();
            _lobbyModificationHandle = null;
        }
    }

    public class LobbyGetAttribute
    {
        private EosLobby _lobby;
        private readonly LobbyInterface _lobbyInterface;
        private LobbyDetails _lobbyDetailsHandle;
        
        ~LobbyGetAttribute()
        {
            _lobbyDetailsHandle.Release();
        }
        
        public LobbyGetAttribute(EosLobby lobby)
        {
            _lobby = lobby;
            _lobbyInterface = EOSSDKComponent.GetLobbyInterface();
            var copyLobbyDetailsHandleOptions = new CopyLobbyDetailsHandleOptions()
            {
                LocalUserId = EOSSDKComponent.LocalUserProductId,
                LobbyId = _lobby.LobbyId
            };
            _lobbyInterface.CopyLobbyDetailsHandle(ref copyLobbyDetailsHandleOptions, out _lobbyDetailsHandle);
        }

        public LobbyGetAttribute(LobbyDetails lobbyDetailsHandle)
        {
            _lobbyDetailsHandle = lobbyDetailsHandle;
        }
        
        public AttributeDataValue? GetAttribute(string key)
        {
            var copyAttributeByValueOptions = new LobbyDetailsCopyAttributeByKeyOptions()
            {
                AttrKey = key
            };
            _lobbyDetailsHandle.CopyAttributeByKey(ref copyAttributeByValueOptions, out var attribute);
            
            if (attribute.HasValue)
            {
                return attribute.Value.Data?.Value;
            }

            return null;
        }

        public ProductUserId GetOwner()
        {
            LobbyDetailsGetLobbyOwnerOptions ownerOptions = new();
            var owner = _lobbyDetailsHandle.GetLobbyOwner(ref ownerOptions);
            return owner;
        }
    }
    
    
    public class LobbyAttributes
    {
        private EosLobby _lobby;
        public LobbyAttributes(EosLobby lobby)
        {
            _lobby = lobby;
        }
    }
    
    public class EosLobby
    {
        private LobbyInterface _lobbyInterface;
        
        public string LobbyId { get; set; }
        
        public LobbySetAttribute AttributeSetter => new LobbySetAttribute(this);
        public LobbyGetAttribute AttributeGetter => new LobbyGetAttribute(this);

        public EosLobby()
        {
            if (!EOSSDKComponent.Initialized)
            {
                _lobbyInterface = null;
                return;
            }
            _lobbyInterface = EOSSDKComponent.GetLobbyInterface();
        }

        public void Leave()
        {
            if (_lobbyInterface == null) return;
            var leaveOptions = new LeaveLobbyOptions
            {
                LocalUserId = EOSSDKComponent.LocalUserProductId,
                LobbyId = LobbyId
            };
            _lobbyInterface.LeaveLobby(ref leaveOptions, null, (ref LeaveLobbyCallbackInfo data) =>
            {
                if (data.ResultCode != Result.Success)
                {
                    Debug.LogError("LeaveLobby failed with " + data.ResultCode);
                }

                Debug.Log("Successfully left lobby " + data.LobbyId.ToString());
            });
        }

        public void Destroy()
        {
            if (_lobbyInterface == null) return;
            DestroyLobbyOptions destroyLobbyOptions = new()
            {
                LocalUserId = EOSSDKComponent.LocalUserProductId,
                LobbyId = LobbyId
            };
            
            if (_lobbyInterface != null)
            {
                _lobbyInterface.DestroyLobby(ref destroyLobbyOptions, null,
                    (ref DestroyLobbyCallbackInfo data) => {});
            }
        }

        public static void CreateLobby(string lobbyId, Action<EosLobby> callback)
        {
            var lobbyInterface = EOSSDKComponent.GetLobbyInterface();

            var options = new CreateLobbyOptions
            {
                LobbyId = lobbyId,
                PermissionLevel = LobbyPermissionLevel.Joinviapresence,
                AllowInvites = false,
                PresenceEnabled = false,
                CrossplayOptOut = true,
                LocalUserId = EOSSDKComponent.LocalUserProductId,
                MaxLobbyMembers = 4,
                EnableJoinById = true,
                BucketId = "global"
            };
            
            lobbyInterface.CreateLobby(ref options, null, (ref CreateLobbyCallbackInfo info) =>
            {
                if (info.ResultCode == Result.Success)
                {
                    callback(new EosLobby
                    {
                        LobbyId = lobbyId
                    });
                }
#if UNITY_SWITCH
                else if (info.ResultCode == Result.PermissionOnlinePlayRestricted)
                {
                    nn.Result result = nn.account.Account.ShowLicenseRequirementsForNetworkService(AccountManager.Primary.Handle);
                }
#endif
                else
                {
                    Debug.LogError($"Failed to create lobby: {info.ResultCode}");
                    callback(null);
                }
            });
        }

        public static void JoinLobbyById(string lobbyId, Action<EosLobby, Result> callback)
        {
            var lobbyInterface = EOSSDKComponent.GetLobbyInterface();
            
            var options = new JoinLobbyByIdOptions
            {
                LocalUserId = EOSSDKComponent.LocalUserProductId,
                CrossplayOptOut = true,
                PresenceEnabled = false,
                LobbyId = lobbyId
            };

            lobbyInterface.JoinLobbyById(ref options, null,
                (ref JoinLobbyByIdCallbackInfo data) =>
                {
                    if (data.ResultCode != Result.Success)
                    {
                        Debug.LogError("Join failed with " + data.ResultCode);
                        callback(null, data.ResultCode);
                        return;
                    }

                    Debug.Log("Successfully joined lobby " + data.LobbyId.ToString());
                    
                    callback(new EosLobby
                    {
                        LobbyId = lobbyId
                    }, Result.Success);
                });

        }

        public static void FindLobbyDetailsById(string lobbyId, Action<LobbyDetails> callback)
        {
            var lobbyInterface = EOSSDKComponent.GetLobbyInterface();
            var createLobbySearchOptions = new CreateLobbySearchOptions
            {
                MaxResults = 1
            };
            lobbyInterface.CreateLobbySearch(ref createLobbySearchOptions, out var lobbySearchHandle);
            var setLobbyIdOptions = new LobbySearchSetLobbyIdOptions
            {
                LobbyId = lobbyId
            };
            lobbySearchHandle.SetLobbyId(ref setLobbyIdOptions);
            var findOptions = new LobbySearchFindOptions
            {
                LocalUserId = EOSSDKComponent.LocalUserProductId
            };

            lobbySearchHandle.Find(ref findOptions, null, (ref LobbySearchFindCallbackInfo data) =>
            {
                if (data.ResultCode != Result.Success)
                {
                    Debug.LogError("GameFromLobbyId: " + data.ResultCode);
                    callback(null);
                    return;
                }

                var copySearchOption = new LobbySearchCopySearchResultByIndexOptions { LobbyIndex = 0 };
                lobbySearchHandle.CopySearchResultByIndex(ref copySearchOption, out var lobbyDetailsHandle);
                callback(lobbyDetailsHandle);
            });
        }
    }
}