using System;
using System.Windows.Input;

namespace VierGewinnt.WpfClient
{
    public class NeuesSpielCommand : IMenuCommand
    {
        private readonly IMainViewModel _mainViewModel;

        private string _name = "Neues Spiel";

        private int _spaltenIndex = 0;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int SpaltenIndex
        {
            get
            {
                return _spaltenIndex;
            }
            set
            {
                _spaltenIndex = value;
            }
        }

        public event EventHandler CanExecuteChanged;

        public NeuesSpielCommand(IMainViewModel mainViewModel, int index)
        {
            if (mainViewModel == null) throw new ArgumentNullException("mainViewModel");

            _mainViewModel = mainViewModel;
            SpaltenIndex = index;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainViewModel.NeuesSpiel();
        }
    }
}
