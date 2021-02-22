using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using OpenDeck.Server.API;
using System;

namespace OpenDeck.Client
{
    public class ButtonPage : UserControl
    {
        private Avalonia.Controls.Button[,] Buttons = new Avalonia.Controls.Button[5, 3];
        private OpenDeckEngine Engine;

        public ButtonPage()
        {
            InitializeComponent();      
        }
        public void LoadButtons(OpenDeckEngine Engine)
        {
            this.Engine = Engine;
            this.Engine.onButtonAdded += Engine_onButtonAdded;
        }
        private void Engine_onButtonAdded(object? sender, Server.API.Events.ButtonAddedEventArgs e)
        {
            if (e.Button != null)
            {
                Dispatcher.UIThread.InvokeAsync((Action)(() => 
                {
                    this.Buttons[e.Button.ButtonX, e.Button.ButtonY].Content = e.Button.Name;
                    this.Buttons[e.Button.ButtonX, e.Button.ButtonY].Background = new ImageBrush(new Bitmap(Environment.CurrentDirectory + "\\res\\" + e.Button.Icon));
                }));
            }
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    this.Buttons[x, y] = this.FindControl<Avalonia.Controls.Button>(x.ToString() + "," + y.ToString());
                }
            }
        }
    }
}
