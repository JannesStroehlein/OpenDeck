using OpenDeck.Server.API.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDeck.Server.API.Events
{
    public class ButtonRemovedEventArgs : EventArgs
    {
        public ActionScope WhoRemoved;
        public JSONButton Button;

        public ButtonRemovedEventArgs(ActionScope WhoAdded, JSONButton Button)
        {
            this.WhoRemoved = WhoAdded;
            this.Button = Button;
        }
    }
}
