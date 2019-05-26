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
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged
    {
        private static MainViewModel _instance;
        private List<IMenuCommand> _menuCommands;
        private BaseViewModel _viewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    InitializeMenu();
                    OnPropertyChanged();
                }
            }
        }

        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainViewModel();
                }
                return _instance;
            }
        }

        public List<IMenuCommand> MenuCommands
        {
            get
            {
                return _menuCommands;
            }
            set
            {
                if (_menuCommands != value)
                {
                    _menuCommands = value;
                    OnPropertyChanged();
                }
            }
        }

        private MainViewModel()
        {

        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void InitializeMenu()
        {
            MenuCommands = new List<IMenuCommand>();
            if (ViewModel.MenuCommands != null)
                for (int i = 0; i < ViewModel.MenuCommands.Count; i++)
                {
                    ViewModel.MenuCommands[i].SpaltenIndex = i;
                    MenuCommands.Add(ViewModel.MenuCommands[i]);
                }
        }
        public void NeuesSpiel()
        {
            MainViewModel.Instance.ViewModel = StartPageViewModel.Instance;
        }
    }
}
