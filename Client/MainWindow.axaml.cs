using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.ComponentModel;
using OpenDeck.Server.API;

namespace OpenDeck.Client
{
    public class MainWindow : Window
    {
        private OpenDeckEngine Engine;
        public MainWindow()
        {
            InitializeComponent();
            this.Engine = new OpenDeckEngine(Server.API.Actions.ActionScope.Client);

            ButtonPage buttonPage = new ButtonPage();
            buttonPage.LoadButtons(this.Engine);
            this.Content = buttonPage;
            #if DEBUG
            this.AttachDevTools();
            #endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            this.Engine.Stop();
        }
    }
}
