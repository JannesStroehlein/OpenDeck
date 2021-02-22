using Avalonia;
using ClientMVVM.Views;
using OpenDeck.Server.API;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace ClientMVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
        }
        public int FontSize => 30;
        public Thickness ButtonMargrin => new Thickness(15);
        public bool DebugGrid => Debugger.IsAttached;
        public string Greeting => "Welcome to Avalonia!";
    }
}
