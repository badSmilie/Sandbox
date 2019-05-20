using System.Collections.Generic;
using System.ComponentModel;
using VierGewinnt.WpfClient.SampleData;
using VierGewinntCore;

namespace VierGewinnt.WpfClient.SampleData
{
    public class SpielViewModelSampleData : ISpielViewModel
    {
        private IReadOnlyList<ISpielerViewModel> spielerViewModels;

        private readonly ISpielbrettViewModel spielbrettViewModel;
        public IReadOnlyList<ISpielerViewModel> SpielerViewModels => spielerViewModels;
        public ISpielbrettViewModel SpielbrettViewModel => spielbrettViewModel;

        public string Gewinnername
        {
            get
            {
                return spielerViewModels[0].Spieler.Name;
            }
        }

        public SpielViewModelSampleData()
        {
            var sampleSpielerViewModels = new List<ISpielerViewModel>();
            sampleSpielerViewModels.Add(new SpielerViewModelSampleData("Player A", new Farbe(0, 0, 255)));
            sampleSpielerViewModels.Add(new SpielerViewModelSampleData("Player B", new Farbe(0, 255, 0))
            {
                IstDran = false
            });

            spielerViewModels = sampleSpielerViewModels;

            spielbrettViewModel = new SpielbrettViewSampleData();
        }

        public void SpieleZug(ISpalte spalte)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
