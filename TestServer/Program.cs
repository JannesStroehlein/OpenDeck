using System;
using OpenDeck.Server.API;

namespace TestServer
{
    class Program
    {
        public static OpenDeckEngine Engine;
        static void Main(string[] args)
        {
            Engine = new OpenDeckEngine(OpenDeck.Server.API.Actions.ActionScope.Server);
            Engine.AddButton(new JSONButton()
            {
                Name = "Test",
                Tooltip = "Test",
                Icon = "128.jpg",
                Position = 0,
                Scope = OpenDeck.Server.API.Actions.ActionScope.Client,
                ActionCMD = "SOUND",
                ActionArgs = "Hyperscape Drop.mp3"
            }) ;

            Console.ReadKey();
            Engine.AddButton(new JSONButton()
            {
                Name = "Test",
                Tooltip = "Test",
                Icon = "128.jpg",
                Position = 5,
                Scope = OpenDeck.Server.API.Actions.ActionScope.Client,
                ActionCMD = "SOUND",
                ActionArgs = "Hyperscape Drop.mp3"
            });
            Console.ReadKey();
        }
    }
}
