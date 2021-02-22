using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpConfig;

namespace OpenDeck.Server.API
{
    public class Configuration
    {
        private SharpConfig.Configuration Settings;
        private string Path;
        public string ServerIP
        { 
            get 
            { 
                return this.Settings["Server"]["IP"].StringValue;
            } 
            set 
            {
                this.Settings["Server"]["IP"].StringValue = value;
            } 
        }
        public int ServerPort
        {
            get
            {
                return this.Settings["Server"]["Port"].IntValue;
            }
            set
            {
                this.Settings["Server"]["Port"].IntValue = value;
            }
        }
        public Configuration(string path)
        {
            this.Path = path;
            if (!File.Exists(path))
            {
                SharpConfig.Configuration settings = new SharpConfig.Configuration();
                settings.Add("Server");
                settings["Server"].Add("IP", "127.0.0.1");
                settings["Server"].Add("Port", 31651);

                settings.SaveToFile(this.Path);
            }
            this.Settings = SharpConfig.Configuration.LoadFromFile(this.Path);
        }
        public void SaveConfig() => this.Settings.SaveToFile(this.Path);
    }
}
