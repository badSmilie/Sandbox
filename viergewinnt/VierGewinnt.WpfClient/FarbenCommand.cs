using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    class FarbenCommand : ICommand
    {
        private readonly Farbe _farbe;
        private readonly IStartPageViewModel _startPageViewModel;
        private int _spaltenIndex;
        public int SpaltenIndex
        {
            get
            {
                return _spaltenIndex;
            }
        }
        public Farbe Farbe => _farbe;

        public event EventHandler CanExecuteChanged;

        public FarbenCommand(Farbe farbe, int id, IStartPageViewModel startPageViewModel)
        {
            if (farbe == null) throw new ArgumentNullException("farbe");
            if (startPageViewModel == null) throw new ArgumentNullException("startPageViewModel");

            _farbe = farbe;
            _startPageViewModel = startPageViewModel;
            _spaltenIndex = id;
        }
        private void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _startPageViewModel.SetzeFarbe(Farbe);
        }
    }
}
