using System;
using System.Windows.Input;

namespace VierGewinnt.WpfClient
{
    public class StartSpielCommand : ICommand
    {
        private readonly IStartPageViewModel _startPageViewModel;

        public event EventHandler CanExecuteChanged;

        public StartSpielCommand(IStartPageViewModel startPageViewModel)
        {
            if (startPageViewModel == null) throw new ArgumentNullException("startPageViewModel");

            _startPageViewModel = startPageViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return string.IsNullOrEmpty(_startPageViewModel.SpielerNameA) == false && string.IsNullOrEmpty(_startPageViewModel.SpielerNameB) == false;
        }

        public void Execute(object parameter)
        {
            _startPageViewModel.StarteSpiel();
        }
    }
}
