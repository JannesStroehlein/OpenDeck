using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDeck.Server.API.Actions
{
    /// <summary>
    /// Use this class to define custom actions
    /// </summary>
    public abstract class ActionType
    {
        public ActionScope ActionScope { get; private set; }
        public ActionType(ActionScope scope)
        {
            this.ActionScope = scope;
        }
        public abstract void RunAction();
    }
}
