using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDeck.Server.API.Actions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ActionAttribute : Attribute
    {
        public ActionScope Scope;
        
        public ActionAttribute(ActionScope Scope)
        {
            this.Scope = Scope;
        }
    }
}
