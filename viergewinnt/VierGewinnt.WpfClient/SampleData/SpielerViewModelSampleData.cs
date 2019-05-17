using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VierGewinntCore;

namespace VierGewinnt.WpfClient.SampleData
{
    public class SpielerViewModelSampleData : ISpielerViewModel
    {
        private readonly Spieler spieler;

        public SpielerViewModelSampleData() : this("Player B", new Farbe(0, 0, 255))
        {
            
        }

        public SpielerViewModelSampleData(string pSpielerName, Farbe pFarbe)
        {
            List<Spielstein> spielsteine = new List<Spielstein>();
            for (int i = 0; i < 21; i++)
            {
                spielsteine.Add(new Spielstein(pFarbe, pSpielerName));
            }
            spieler = new Spieler(pSpielerName, spielsteine, pFarbe);

            IstDran = true;
        }
        public Spieler Spieler
        {
            get
            {
                return spieler;
            }
        }

        public bool IstDran
        {
            get; set;
        }
    }
}
