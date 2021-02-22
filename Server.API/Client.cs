using SimpleSockets;
using SimpleSockets.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenDeck.Server.API
{
    class Client
    {
        private OpenDeckEngine Engine;
        private SimpleSocketTcpClient TCPClient;
        public Client(string IP, int port, OpenDeckEngine Engine)
        {
            this.Engine = Engine;
            this.TCPClient = new SimpleSocketTcpClient();
            this.TCPClient.AllowReceivingFiles = true;
            this.TCPClient.FileReceiver += TCPClient_FileReceiver;
            this.TCPClient.MessageReceived += TCPClient_MessageReceived;
            this.TCPClient.ConnectedToServer += TCPClient_ConnectedToServer;
            this.TCPClient.DisconnectedFromServer += TCPClient_DisconnectedFromServer;
            this.TCPClient.StartClient(IP, port);
        }

        private void TCPClient_DisconnectedFromServer(SimpleSocketClient client)
        {
            Debug.WriteLine("Disconnected from server");
        }
        private void TCPClient_ConnectedToServer(SimpleSocketClient client)
        {
            this.TCPClient.SendMessage("Sync");
            Debug.WriteLine("Connected to server");
        }
        private void TCPClient_MessageReceived(SimpleSocketClient client, string msg)
        {
            Debug.WriteLine("Message Received: " + msg);
            this.Engine.AddButton(JSONButton.FromJSON(msg));
        }
        private void TCPClient_FileReceiver(SimpleSocketClient client, int currentPart, int totalPart, string location, SimpleSockets.Messaging.MessageState state)
        {
            Debug.WriteLine("Resived File: " + location + " State: " + state);
        }
    }
}
