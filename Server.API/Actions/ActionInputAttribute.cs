using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDeck.Server.API.Actions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ActionInputAttribute : Attribute
    {
        public string Description;
        public ActionInputAttribute(string Description)
        {
            this.Description = Description;
        }
    }
}
