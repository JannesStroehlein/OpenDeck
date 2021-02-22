using OpenDeck.Server.API.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDeck.Server.API.Events
{
    public class ButtonAddedEventArgs : EventArgs
    {
        public ActionScope WhoAdded;
        public JSONButton Button;

        public ButtonAddedEventArgs(ActionScope WhoAdded, JSONButton Button)
        {
            this.WhoAdded = WhoAdded;
            this.Button = Button;
        }
    }
}
