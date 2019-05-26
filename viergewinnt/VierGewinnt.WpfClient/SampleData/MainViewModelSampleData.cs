using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VierGewinntCore;

namespace VierGewinnt.WpfClient.SampleData
{
    public class MainViewModelSampleData : IMainViewModel, INotifyPropertyChanged
    {
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
                    OnPropertyChanged();
                }
            }
        }

        public MainViewModelSampleData()
        {
            InitializeMenu();
        }

        public List<IMenuCommand> MenuCommands
        {
            get
            {
                return _menuCommands;
            }
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
            _menuCommands = new List<IMenuCommand>();
            _menuCommands.Add(new NeuesSpielCommand(this, 0));
        }
        public void NeuesSpiel()
        {
            
        }
    }
}
