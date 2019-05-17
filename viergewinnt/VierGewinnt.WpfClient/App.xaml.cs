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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Spieler spielerA = ErstelleSpieler(new Farbe(0, 0, 128), "Spieler A");
            Spieler spielerB = ErstelleSpieler(new Farbe(128, 0, 0), "Spieler B");
            List<PlatzViewModelDecorator> plaetze = new List<PlatzViewModelDecorator>();
            Spielbrett spielbrett = new SpielbrettFactory(new PlatzViewModelDecoratorFactory(plaetze)).Create(6, 7);
            List<IClickColumnCommand> clickCommands = new List<IClickColumnCommand>();
            SpielbrettViewModel spielbrettViewModel = new SpielbrettViewModel(plaetze, clickCommands, spielbrett.Spalten);
            List<SpielerViewModel> spielerViewModels = new List<SpielerViewModel> { new SpielerViewModel(spielerA) { IstDran = true },
                                                                                    new SpielerViewModel(spielerB)};
  
            MainWindowViewModel mainviewmodel = new MainWindowViewModel(spielerViewModels, spielbrettViewModel, spielbrett);
            clickCommands.AddRange(spielbrett.Spalten.Select(item => new KlickSpalteCommand(item, mainviewmodel)));
            MainWindow mainWindow = new MainWindow { DataContext = mainviewmodel };
            mainWindow.Show();
        }

        private Spieler ErstelleSpieler(Farbe farbe, string name)
        {
            List<Spielstein> lSteine = new List<Spielstein>();
            for (int i = 0; i < 21; i++)
            {
                lSteine.Add(new Spielstein(farbe, name));
            }

            return new Spieler(name, lSteine, farbe);
        }
    }
}
