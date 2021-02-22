using OpenDeck.Server.API.Actions;
using OpenDeck.Server.API.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace OpenDeck.Server.API
{
    public class OpenDeckEngine
    {
        public const int ButtonsX = 5;
        public const int ButtonsY = 3;

        private Server Server;
        private Client Client;

        #region Events
        /// <summary>
        /// This event will be raised whenever a button gets added.
        /// </summary>
        public event EventHandler<ButtonAddedEventArgs> onButtonAdded;
        /// <summary>
        /// This event will be raised whenever a button gets removed.
        /// </summary>
        public event EventHandler<ButtonRemovedEventArgs> onButtonRemoved;
        #endregion

        public ObservableCollection<JSONButton> Buttons = new ObservableCollection<JSONButton>();
        public ActionScope Scope { get; private set; }
        public Configuration Config { get; private set; }
        public List<ButtonAction> ClientActions { get; private set; }
        public List<ButtonAction> ServerActions { get; private set; }

        public OpenDeckEngine(ActionScope Scope)
        {
            this.Scope = Scope;
            this.Config = new Configuration("config.cfg");
            if (!Directory.Exists("Addons"))
                Directory.CreateDirectory("Addons");
            string[] addonFileNames = Directory.GetFiles("Addons", "*.dll");
            foreach (string addonFileName in addonFileNames)
                Assembly.Load(addonFileName);
            if (this.Scope == ActionScope.Client)
                this.Client = new Client(this.Config.ServerIP, this.Config.ServerPort, this);
            else
                this.Server = new Server(this.Config.ServerIP, this.Config.ServerPort, this);
        }
        public void AddButton(JSONButton button)
        {
            if (this.Scope == ActionScope.Server)
            {
                this.Server.SendButton(button);
            }
            this.Buttons.Add(button);
            EventHandler<ButtonAddedEventArgs> handler = onButtonAdded;
            if (handler != null)
            {
                handler(null, new ButtonAddedEventArgs(this.Scope, button));
            }
        }
        public void Stop()
        {
            this.Config.SaveConfig();
        }
    }
}
