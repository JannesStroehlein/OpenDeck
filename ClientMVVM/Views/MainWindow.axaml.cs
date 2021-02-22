using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OpenDeck.Server.API;
using System.IO;
using System;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using NAudio;
using NAudio.Wave;

namespace ClientMVVM.Views
{
    public class MainWindow : Window
    {
        public static OpenDeckEngine Engine;
        private WaveOut waveOut = new WaveOutEvent();

        public MainWindow()
        {
            InitializeComponent();
            #if DEBUG
            this.AttachDevTools();
            #endif
            if (!Directory.Exists(Environment.CurrentDirectory + "//res"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "//res");
            Engine = new OpenDeckEngine(OpenDeck.Server.API.Actions.ActionScope.Client);
            Engine.onButtonAdded += Engine_onButtonAdded;
        }

        private void Engine_onButtonAdded(object? sender, OpenDeck.Server.API.Events.ButtonAddedEventArgs e)
        {
            if (e.Button != null)
            {
                JSONButton button = e.Button;
                Dispatcher.UIThread.InvokeAsync((Action)(() =>
                {
                    this.FindControl<Button>("Button" + button.Position).Tag = button;
                    this.FindControl<Button>("Button" + button.Position).Background = new ImageBrush(new Bitmap(Environment.CurrentDirectory + @"\res\" + button.Icon));                  
                }));
            }
        }
        private void Button_onClick(object sender, RoutedEventArgs e)
        {
            JSONButton button = ((Button)sender).Tag as JSONButton;
            if (button.Scope == OpenDeck.Server.API.Actions.ActionScope.Client)
            {
                switch (button.ActionCMD)
                {
                    case "SOUND":

                        break;
                }
            }
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
