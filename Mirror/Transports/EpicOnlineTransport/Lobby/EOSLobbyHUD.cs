using System;
using Epic.OnlineServices.Lobby;
using UnityEngine;
using System.Collections.Generic;
using EpicTransport;
using Mirror;
using Attribute = Epic.OnlineServices.Lobby.Attribute;

[RequireComponent(typeof(EOSLobby))]
public class EOSLobbyHUD : MonoBehaviour {
    private EOSLobby _eosLobby;
    
    [Header("Network Manager")]
    public NetworkManager manager;
    
    [Header("Lobby Settings")]
    public string lobbyName = "My Lobby";
    
    private bool _showLobbyList = false;
    private bool _showPlayerList = false;

    private List<LobbyDetails> _foundLobbies = new List<LobbyDetails>();
    private List<Attribute> _lobbyData = new List<Attribute>();

    private const string LobbyNameKey = "LobbyName";

    private void Awake()
    {
        _eosLobby = GetComponent<EOSLobby>();
    }

    //register events
    private void OnEnable() {
        //subscribe to events
        _eosLobby.CreateLobbySucceeded += OnCreateLobbySuccess;
        _eosLobby.JoinLobbySucceeded += OnJoinLobbySuccess;
        _eosLobby.FindLobbiesSucceeded += OnFindLobbiesSuccess;
        _eosLobby.LeaveLobbySucceeded += OnLeaveLobbySuccess;
    }

    //deregister events
    private void OnDisable() {
        //unsubscribe from events
        _eosLobby.CreateLobbySucceeded -= OnCreateLobbySuccess;
        _eosLobby.JoinLobbySucceeded -= OnJoinLobbySuccess;
        _eosLobby.FindLobbiesSucceeded -= OnFindLobbiesSuccess;
        _eosLobby.LeaveLobbySucceeded -= OnLeaveLobbySuccess;
    }

    //when the lobby is successfully created, start the host
    private void OnCreateLobbySuccess(List<Attribute> attributes) {
        _lobbyData = attributes;
        _showPlayerList = true;
        _showLobbyList = false;

        manager.StartHost();
    }

    //when the user joined the lobby successfully, set network address and connect
    private void OnJoinLobbySuccess(List<Attribute> attributes) {
        _lobbyData = attributes;
        _showPlayerList = true;
        _showLobbyList = false;

        Attribute hostAddressAttribute = attributes.Find((x) => x.Data.HasValue && x.Data.Value.Key == EOSLobby.hostAddressKey);
        if (!hostAddressAttribute.Data.HasValue)
        {
            Debug.LogError("Host address not found in lobby attributes. Cannot connect to host.");
            return;
        }

        manager.networkAddress = hostAddressAttribute.Data.Value.Value.AsUtf8;
        manager.StartClient();
    }

    //callback for FindLobbiesSucceeded
    private void OnFindLobbiesSuccess(List<LobbyDetails> lobbiesFound) {
        _foundLobbies = lobbiesFound;
        _showPlayerList = false;
        _showLobbyList = true;
    }

    //when the lobby was left successfully, stop the host/client
    private void OnLeaveLobbySuccess() {
        manager.StopHost();
        manager.StopClient();
    }

    private void OnGUI() {
        // Debug.LogError("OnGUI");
        //if the component is not initialized then dont continue
        if (!EOSSDKComponent.Initialized) {
            return;
        }

        //start UI
        GUILayout.BeginHorizontal();

        //draw side buttons
        DrawMenuButtons();

        //draw scroll view
        GUILayout.BeginScrollView(Vector2.zero, GUILayout.MaxHeight(400));

        //runs when we want to show the lobby list
        if (_showLobbyList && !_showPlayerList) {
            DrawLobbyList();
        }
        //runs when we want to show the player list and we are connected to a lobby
        else if (!_showLobbyList && _showPlayerList && _eosLobby.ConnectedToLobby) {
            DrawLobbyMenu();
        }

        GUILayout.EndScrollView();

        GUILayout.EndHorizontal();
    }

    private void DrawMenuButtons() {
        //start button column
        GUILayout.BeginVertical();

        //decide if we should enable the create and find lobby buttons
        //prevents user from creating or searching for lobbies when in a lobby
        GUI.enabled = !_eosLobby.ConnectedToLobby;

        #region Draw Create Lobby Button

        GUILayout.BeginHorizontal();

        //create lobby button
        if (GUILayout.Button("Create Lobby")) {
            _eosLobby.CreateLobby(4, LobbyPermissionLevel.Publicadvertised, false,
                new AttributeData[]
                {
                    new AttributeData
                    {
                        Key = LobbyNameKey, Value = lobbyName
                    },
                });
        }

        lobbyName = GUILayout.TextField(lobbyName, 40, GUILayout.Width(200));

        GUILayout.EndHorizontal();

        #endregion

        //find lobby button
        if (GUILayout.Button("Find Lobbies")) {
            _eosLobby.FindLobbies();
        }

        //decide if we should enable the leave lobby button
        //only enabled when the user is connected to a lobby
        GUI.enabled = _eosLobby.ConnectedToLobby;

        if (GUILayout.Button("Leave Lobby")) {
            _eosLobby.LeaveLobby();
        }

        GUI.enabled = true;

        GUILayout.EndVertical();
    }

    private void DrawLobbyList() {
        //draw labels
        GUILayout.BeginHorizontal();
        GUILayout.Label("Lobby Name", GUILayout.Width(220));
        GUILayout.Label("Player Count");
        GUILayout.EndHorizontal();

        //draw lobbies
        foreach (LobbyDetails lobby in _foundLobbies) {
            //get lobby name
            Attribute? lobbyNameAttribute = new Attribute();
            LobbyDetailsCopyAttributeByKeyOptions copyOptions = new LobbyDetailsCopyAttributeByKeyOptions { AttrKey = LobbyNameKey };
            lobby.CopyAttributeByKey(ref copyOptions, out lobbyNameAttribute);

            //draw the lobby result
            GUILayout.BeginHorizontal(GUILayout.Width(400), GUILayout.MaxWidth(400));

            if (lobbyNameAttribute.HasValue && lobbyNameAttribute.Value.Data.HasValue)
            {
                var data = lobbyNameAttribute.Value.Data.Value;
                //draw lobby name
                GUILayout.Label(data.Value.AsUtf8.Length > 30 ? data.Value.AsUtf8.ToString().Substring(0, 27).Trim() + "..." : data.Value.AsUtf8, GUILayout.Width(175));
                GUILayout.Space(75);
            }
            //draw player count
            LobbyDetailsGetMemberCountOptions memberCountOptions = new LobbyDetailsGetMemberCountOptions { };
            GUILayout.Label(lobby.GetMemberCount(ref memberCountOptions).ToString());
            GUILayout.Space(75);

            //draw join button
            if (GUILayout.Button("Join", GUILayout.ExpandWidth(false))) {
                _eosLobby.JoinLobby(lobby, new []{ LobbyNameKey });
            }

            GUILayout.EndHorizontal();
        }
    }

    private void DrawLobbyMenu() {
        //draws the lobby name
        var lobbyNameAttribute = _lobbyData.Find((x) => x.Data.HasValue && x.Data.Value.Key == LobbyNameKey);
        if (!lobbyNameAttribute.Data.HasValue) {
            return;
        }
        GUILayout.Label("Name: " + lobbyNameAttribute.Data.Value.Value.AsUtf8);

        //draws players
        LobbyDetailsGetMemberCountOptions memberCountOptions = new LobbyDetailsGetMemberCountOptions();
        var playerCount = _eosLobby.ConnectedLobbyDetails.GetMemberCount(ref memberCountOptions);
        for (int i = 0; i < playerCount; i++) {
            GUILayout.Label("Player " + i);
        }
    }
}
