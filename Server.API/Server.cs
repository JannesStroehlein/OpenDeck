using SimpleSockets.Messaging.Metadata;
using SimpleSockets.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

namespace OpenDeck.Server.API
{
    class Server
    {
        private SimpleSocketTcpListener TCPServer;
        private OpenDeckEngine Engine;
        public Server(string IP, int Port, OpenDeckEngine Engine)
        {
            this.Engine = Engine;
            this.TCPServer = new SimpleSocketTcpListener();
            this.TCPServer.MessageReceived += TCPServer_MessageReceived;
            this.TCPServer.ClientConnected += TCPServer_ClientConnected;
            this.TCPServer.ClientDisconnected += TCPServer_ClientDisconnected;
            this.TCPServer.StartListening(IP, Port);
        }
        private void TCPServer_ClientConnected(IClientInfo clientInfo)
        {
            Debug.WriteLine("[+] " + clientInfo.ClientName);
            Console.WriteLine("[+] " + clientInfo.ToString());
        }
        private void TCPServer_ClientDisconnected(IClientInfo client, SimpleSockets.DisconnectReason reason)
        {
            Debug.WriteLine("[-] " + client.ClientName);
            Console.WriteLine("[-] " + client.ToString());
        }
        private void TCPServer_MessageReceived(IClientInfo client, string message)
        {
            if (message == "Sync")
            {
                Console.WriteLine("Sync");
                foreach (JSONButton button in this.Engine.Buttons)
                {
                    if (button != null)
                        this.SendButton(button);
                }
            }
        }
        public void SendButton(JSONButton button, IClientInfo client = null)
        {
            if (client == null)
            {
                foreach (IClientInfo clientInfo in this.TCPServer.GetConnectedClients().Values)
                    this.SendButton(button, clientInfo);
            }
            else
            {
                this.TCPServer.SendFile(client.Id, button.Icon, button.Icon);
                Console.WriteLine("Icon Sent File Sent");
                this.TCPServer.SendMessage(client.Id, button.ToString());
                Console.WriteLine("Info JSON Sent");
                if (button.Scope == Actions.ActionScope.Client)
                {
                    switch (button.ActionCMD)
                    {
                        case "SOUND":
                            this.TCPServer.SendFile(client.Id, button.ActionArgs, button.ActionArgs); Console.WriteLine("Sent " + button.ActionArgs); break;
                    }
                }
            }
        }
    }
}
