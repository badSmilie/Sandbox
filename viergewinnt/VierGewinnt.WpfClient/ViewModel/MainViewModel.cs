using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged
    {
        private static MainViewModel _instance;

        private object _viewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public object ViewModel
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
    }
}
