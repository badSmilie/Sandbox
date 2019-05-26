using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    public class StartPageViewModel : BaseViewModel, IStartPageViewModel, INotifyPropertyChanged
    {
        private string _spielerNameA;
        private string _spielerNameB;
        private List<ICommand> _farbenCommands;
        private Farbe _farbeSpielerA;
        private Farbe _farbeSpielerB;
        private ICommand _starteSpielCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        private static StartPageViewModel _instance;
        public string SpielerNameA
        {
            get
            {
                return _spielerNameA;
            }
            set
            {
                _spielerNameA = value;
                OnPropertyChanged();
            }
        }
        public string SpielerNameB
        {
            get
            {
                return _spielerNameB;
            }
            set
            {
                _spielerNameB = value;
                OnPropertyChanged();
            }
        }

        public ICommand StarteSpielCommand
        {
            get
            {
                return _starteSpielCommand;
            }
        }
        public List<ICommand> FarbenCommands { get => _farbenCommands; }
        public Farbe FarbeSpielerA
        {
            get
            {
                return _farbeSpielerA;
            }
            set
            {
                _farbeSpielerA = value;
                OnPropertyChanged();
            }
        }
        public Farbe FarbeSpielerB
        {
            get
            {
                return _farbeSpielerB;
            }
            set
            {
                _farbeSpielerB = value;
                OnPropertyChanged();
            }
        }
        public static StartPageViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StartPageViewModel();
                    _instance.Initialize();
                }
                return _instance;
            }
        }

        private StartPageViewModel()
        {
            
        }

        private void Initialize()
        {
            SpielerNameA = "Spieler A";
            SpielerNameB = "Spieler B";
            _starteSpielCommand = new StartSpielCommand(this);
            _farbenCommands = new List<ICommand>();
            _farbenCommands.Add(new FarbenCommand(new Farbe(222, 183, 26, "/VierGewinnt.WpfClient;component/Bilder/rosa.png"), 0, this));
            _farbenCommands.Add(new FarbenCommand(new Farbe(62, 203, 119, "/VierGewinnt.WpfClient;component/Bilder/blau.png"), 1, this));
            _farbenCommands.Add(new FarbenCommand(new Farbe(236, 15, 208, "/VierGewinnt.WpfClient;component/Bilder/gelb.png"), 2, this));
            MenuCommands = null;
        }
        
        public void StarteSpiel()
        {
            Spieler spielerA = ErstelleSpieler(FarbeSpielerA, SpielerNameA);
            Spieler spielerB = ErstelleSpieler(FarbeSpielerB, SpielerNameB);

            List<PlatzViewModelDecorator> plaetze = new List<PlatzViewModelDecorator>();
            Spielbrett spielbrett = new SpielbrettFactory(new PlatzViewModelDecoratorFactory(plaetze)).Create(6, 7);
            List<IClickColumnCommand> clickCommands = new List<IClickColumnCommand>();
            SpielbrettViewModel spielbrettViewModel = new SpielbrettViewModel(plaetze, clickCommands, spielbrett.Spalten);
            List<SpielerViewModel> spielerViewModels = new List<SpielerViewModel> { new SpielerViewModel(spielerA) { IstDran = true },
                                                                                    new SpielerViewModel(spielerB)};
            SpielViewModel spielViewModel = new SpielViewModel(spielerViewModels, spielbrettViewModel, spielbrett);
            clickCommands.AddRange(spielbrett.Spalten.Select(item => new KlickSpalteCommand(item, spielViewModel)));
            MainViewModel.Instance.ViewModel = spielViewModel;
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
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

        public void SetzeFarbe(Farbe farbe)
        {
            if (FarbeSpielerA == null)
            {
                FarbeSpielerA = farbe;
            }
            else if (FarbeSpielerB == null)
            {
                FarbeSpielerB = farbe;
            }
        }
    }
}
