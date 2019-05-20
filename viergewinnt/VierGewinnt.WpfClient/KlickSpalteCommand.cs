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
        private readonly ISpielViewModel _spielWindowViewModel;
        public int SpaltenIndex => spalte.Index;

        public event EventHandler CanExecuteChanged;

        public KlickSpalteCommand(ISpalte column, ISpielViewModel spielViewModel)
        {
            if (column == null) throw new ArgumentNullException("column");
            if (spielViewModel == null) throw new ArgumentNullException("spielViewModel");

            spalte = column;
            _spielWindowViewModel = spielViewModel;
            _spielWindowViewModel.PropertyChanged += SpielViewModelPropertyChanged;
        }

        private void SpielViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
            return string.IsNullOrEmpty(_spielWindowViewModel.Gewinnername) && spalte.IstSpalteVoll == false;
        }

        public void Execute(object parameter)
        {
            _spielWindowViewModel.SpieleZug(spalte);
            if (spalte.IstSpalteVoll)
                OnCanExecuteChanged();
        }
    }
}
