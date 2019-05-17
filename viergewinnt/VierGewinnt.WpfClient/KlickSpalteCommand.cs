using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    class KlickSpalteCommand : IClickColumnCommand
    {
        private readonly ISpalte spalte;
        private readonly IMainViewModel _mainWindowViewModel;
        public int SpaltenIndex => spalte.Index;

        public event EventHandler CanExecuteChanged;

        public KlickSpalteCommand(ISpalte column, IMainViewModel mainWindowViewModel)
        {
            if (column == null) throw new ArgumentNullException("column");
            if (mainWindowViewModel == null) throw new ArgumentNullException("mainWindowViewModel");

            spalte = column;
            _mainWindowViewModel = mainWindowViewModel;
            _mainWindowViewModel.PropertyChanged += MainWindowViewModel_PropertyChanged;
        }

        private void MainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Gewinnername")
                OnCanExecuteChanged();
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
            return string.IsNullOrEmpty(_mainWindowViewModel.Gewinnername) && spalte.IstSpalteVoll == false;
        }

        public void Execute(object parameter)
        {
            _mainWindowViewModel.SpieleZug(spalte);
            if (spalte.IstSpalteVoll)
                OnCanExecuteChanged();
        }
    }
}
