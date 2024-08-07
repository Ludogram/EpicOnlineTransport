﻿using Epic.OnlineServices;
using Epic.OnlineServices.P2P;
using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace EpicTransport {
    public class Server : Common {
        private event Action<int> OnConnected;
        private event Action<int, byte[], int> OnReceivedData;
        private event Action<int> OnDisconnected;
        private event Action<int, Exception> OnReceivedError;

        private BidirectionalDictionary<ProductUserId, int> epicToMirrorIds;
        private Dictionary<ProductUserId, SocketId> epicToSocketIds;
        private int maxConnections;
        private int nextConnectionID;

        public static Server CreateServer(EosTransport transport, int maxConnections) {
            Server s = new Server(transport, maxConnections);

            s.OnConnected += (id) => transport.OnServerConnected.Invoke(id);
            s.OnDisconnected += (id) => transport.OnServerDisconnected.Invoke(id);
            s.OnReceivedData += (id, data, channel) => transport.OnServerDataReceived.Invoke(id, new ArraySegment<byte>(data), channel);
            s.OnReceivedError += (id, exception) => transport.OnServerError.Invoke(id, TransportError.Unexpected, exception.ToString());

            if (!EOSSDKComponent.Initialized) {
                Debug.LogError("EOS not initialized.");
            }

            return s;
        }

        private Server(EosTransport transport, int maxConnections) : base(transport) {
            this.maxConnections = maxConnections;
            epicToMirrorIds = new BidirectionalDictionary<ProductUserId, int>();
            epicToSocketIds = new Dictionary<ProductUserId, SocketId>();
            nextConnectionID = 1;
        }

        protected override void OnNewConnection(ref OnIncomingConnectionRequestInfo result) {
            if (ignoreAllMessages) {
                return;
            }

            if (deadSockets.Contains(result.SocketId?.SocketName)) {
                Debug.LogError("Received incoming connection request from dead socket");
                return;
            }

            var acceptConnectionOptions = new AcceptConnectionOptions() {
	            LocalUserId = EOSSDKComponent.LocalUserProductId,
	            RemoteUserId = result.RemoteUserId,
	            SocketId = result.SocketId
            };
            EOSSDKComponent.GetP2PInterface().AcceptConnection(
                ref acceptConnectionOptions);
        }

        protected override void OnReceiveInternalData(InternalMessages type, ProductUserId clientUserId, SocketId socketId) {
            if (ignoreAllMessages) {
                return;
            }

            switch (type) {
                case InternalMessages.CONNECT:
                    if (epicToMirrorIds.Count >= maxConnections) {
                        Debug.LogError("Reached max connections");
                        //CloseP2PSessionWithUser(clientUserId, socketId);
                        SendInternal(clientUserId, socketId, InternalMessages.DISCONNECT);
                        return;
                    }

                    SendInternal(clientUserId, socketId, InternalMessages.ACCEPT_CONNECT);

                    int connectionId = nextConnectionID++;
                    epicToMirrorIds.Add(clientUserId, connectionId);
                    epicToSocketIds.Add(clientUserId, socketId);
                    OnConnected.Invoke(connectionId);

                    Utf8String clientUserIdString;
                    clientUserId.ToString(out clientUserIdString);
                    Debug.Log($"Client with Product User ID {clientUserIdString} connected. Assigning connection id {connectionId}");
                    break;
                case InternalMessages.DISCONNECT:
                    if (epicToMirrorIds.TryGetValue(clientUserId, out int connId)) {
                        Debug.Log($"[InternalMessages.DISCONNECT] Client with Product User ID {clientUserId} and connection id {connId} disconnected.");
                        OnDisconnected.Invoke(connId);
                        //CloseP2PSessionWithUser(clientUserId, socketId);
                        epicToMirrorIds.Remove(clientUserId);
                        epicToSocketIds.Remove(clientUserId);
                        CloseConnectionOptions closeOptions = new CloseConnectionOptions {
                            LocalUserId = EOSSDKComponent.LocalUserProductId,
                            RemoteUserId = clientUserId,
                            SocketId = socketId
                        };
                        p2pInterface.CloseConnection(ref closeOptions);
                    } else {
                        OnReceivedError.Invoke(-1, new Exception("ERROR Unknown Product User ID"));
                    }

                    break;
                default:
                    Debug.Log("Received unknown message type");
                    break;
            }
        }

        protected override void OnReceiveData(byte[] data, ProductUserId clientUserId, int channel) {
            if (ignoreAllMessages) {
                return;
            }

            if (epicToMirrorIds.TryGetValue(clientUserId, out int connectionId)) {
                OnReceivedData.Invoke(connectionId, data, channel);
            } else {
                SocketId socketId;
                epicToSocketIds.TryGetValue(clientUserId, out socketId);
                CloseP2PSessionWithUser(clientUserId, socketId);

                Utf8String productId;
                clientUserId.ToString(out productId);

                Debug.LogError("Data received from epic client thats not known " + productId);
                OnReceivedError.Invoke(-1, new Exception("ERROR Unknown product ID"));
            }
        }

        public void Disconnect(int connectionId) {
            if (epicToMirrorIds.TryGetValue(connectionId, out ProductUserId userId))
            {
                Debug.Log($"EOS: Server disconnecting client with product id {userId} and connection id {connectionId}");
                SocketId socketId;
                epicToSocketIds.TryGetValue(userId, out socketId);
                // epicToMirrorIds.Remove(userId);
                // epicToSocketIds.Remove(userId);
                SendInternal(userId, socketId, InternalMessages.DISCONNECT);
            } else {
                Debug.LogWarning("Trying to disconnect unknown connection id: " + connectionId);
            }
        }

        public void Shutdown() {
            foreach (KeyValuePair<ProductUserId, int> client in epicToMirrorIds) {
                Disconnect(client.Value);
                SocketId socketId;
                epicToSocketIds.TryGetValue(client.Key, out socketId);
                WaitForClose(client.Key, socketId);
            }

            ignoreAllMessages = true;
            ReceiveData();

            Dispose();
        }

        public void SendAll(int connectionId, byte[] data, int channelId) {
            if (epicToMirrorIds.TryGetValue(connectionId, out ProductUserId userId)) {
                SocketId socketId;
                epicToSocketIds.TryGetValue(userId, out socketId);
                Send(userId, socketId, data, (byte)channelId);
            } else {
                Debug.LogWarning("EOS: Trying to send on unknown connection: " + connectionId);
                OnReceivedError.Invoke(connectionId, new Exception("ERROR Unknown Connection"));
            }

        }

        public string ServerGetClientAddress(int connectionId) {
            if (epicToMirrorIds.TryGetValue(connectionId, out ProductUserId userId)) {
                Utf8String userIdString;
                userId.ToString(out userIdString);
                return userIdString;
            } else {
                Debug.LogWarning("EOS: Trying to get info on unknown connection: " + connectionId);
                OnReceivedError.Invoke(connectionId, new Exception("ERROR Unknown Connection"));
                return string.Empty;
            }
        }

        protected override void OnConnectionFailed(ProductUserId remoteId) {
            if (ignoreAllMessages) {
                return;
            }

            if (!epicToMirrorIds.TryGetValue(remoteId, out int connectionId))
            {
                Debug.LogWarning($"EOS: Connection failed, but no mirror id was found for product id {remoteId}");
                return;
            }

            OnDisconnected.Invoke(connectionId);

            Debug.LogWarning($"EOS: Connection Failed, removing user {remoteId} with connection id {connectionId}");
            epicToMirrorIds.Remove(remoteId);
            epicToSocketIds.Remove(remoteId);
        }
    }
}
