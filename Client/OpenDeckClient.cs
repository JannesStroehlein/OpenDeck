using SimpleTcp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDeck.Client
{
    public class OpenDeckClient
    {
        public readonly Configuration Config;
        private SimpleTcpClient Client;
        public OpenDeckClient()
        {
            this.Config = new Configuration("config.cfg");
            this.Client = new SimpleTcpClient(this.Config.ServerIP, this.Config.ServerPort);
            this.Client.Events.Connected += Events_Connected;
            this.Client.Events.DataReceived += Events_DataReceived;
            this.Client.Events.Disconnected += Events_Disconnected;
            this.Client.Connect();
            Debug.WriteLine("Beginning Client work.", "ClientTCP");
            Debugger.Log(0, "Config", "Server | IP: " + Config.ServerIP + "; Port: " + Config.ServerPort + "\n");
        }
        private void Events_Connected(object? sender, ClientConnectedEventArgs e)
        {
            Debug.WriteLine("Connected to " + e.IpPort, "ClientTCP");
        }
        private void Events_DataReceived(object? sender, SimpleTcp.DataReceivedEventArgs e)
        {
            Debug.WriteLine("Recived Data: " + e.Data, "ClientTCP");
        }
        private void Events_Disconnected(object? sender, ClientDisconnectedEventArgs e)
        {
            Debug.WriteLine("Disconnected because " + e.Reason, "ClientTCP");
        }
        public void End()
        {
            Debugger.Log(0, "Client", "The client will be end it's work.\n");
            this.Config.SaveConfig();
        }
    }
}
