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
    public class SpielViewModel : ISpielViewModel, INotifyPropertyChanged
    {
        private readonly IReadOnlyList<ISpielerViewModel> spielerViewModels;
        private readonly ISpielbrettViewModel spielbrettViewModel;
        private readonly Spielbrett spielbrett;
        private string gewinnername;

        public event PropertyChangedEventHandler PropertyChanged;

        public IReadOnlyList<ISpielerViewModel> SpielerViewModels => spielerViewModels;

        public ISpielbrettViewModel SpielbrettViewModel => spielbrettViewModel;

        public string Gewinnername
        {
            get
            {
                return gewinnername;
            }
            set
            {
                if (gewinnername != value)
                {
                    gewinnername = value;
                    OnPropertyChanged();
                }
            }
        }

        public Spielbrett Spielbrett => spielbrett;

        public SpielViewModel(IReadOnlyList<ISpielerViewModel> pSpielerViewModels, ISpielbrettViewModel pSpielbrettViewModel, Spielbrett pSpielbrett)
        {
            spielerViewModels = pSpielerViewModels;
            spielbrettViewModel = pSpielbrettViewModel;
            spielbrett = pSpielbrett;
        }

        public void SpieleZug(ISpalte spalte)
        {
            if (spalte == null) throw new ArgumentNullException("column");

            var currentPlayerViewModel = spielerViewModels.First(vm => vm.IstDran);
            currentPlayerViewModel.Spieler.SpieleZug(spalte);

            Gewinnername = spielbrett.BestimmeGewinnername();
            if (Gewinnername != null)
            {
                return;
            }

            foreach (var spielerModel in spielerViewModels)
            {
                spielerModel.IstDran = !spielerModel.IstDran;
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
    }
}
