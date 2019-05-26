using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private MainViewModel _mainViewModel;
        public MainViewModel MainViewModel { get => _mainViewModel; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            StartPageViewModel startPageViewModel = StartPageViewModel.Instance;
            MainViewModel.Instance.ViewModel = startPageViewModel;
            MainWindow mainWindow = new MainWindow { DataContext = MainViewModel.Instance };
            mainWindow.Show();
        }
    }
}
