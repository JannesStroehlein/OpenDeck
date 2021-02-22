using Newtonsoft.Json;
using OpenDeck.Server.API.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDeck.Server.API
{
    public class JSONButton
    {
        public string Name;
        public string Tooltip;
        public string Icon;
        public int Position;
        public ActionScope Scope;
        public string ActionCMD;
        public string ActionArgs;

        public static JSONButton FromJSON(string JSON)
        {
            return JsonConvert.DeserializeObject<JSONButton>(JSON);
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
