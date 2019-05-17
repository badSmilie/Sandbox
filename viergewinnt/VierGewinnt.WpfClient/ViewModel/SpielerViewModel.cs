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
    public class SpielerViewModel : ISpielerViewModel, INotifyPropertyChanged
    {
        private readonly Spieler spieler;
        private bool istDran;

        public event PropertyChangedEventHandler PropertyChanged;

        public Spieler Spieler => spieler;

        public bool IstDran
        {
            get => istDran;
            set
            {
                if (istDran == value) return;
                istDran = value;
                OnPropertyChanged(); // genügt da unten Attribute CallerMemberName
            }
        }

        public SpielerViewModel(Spieler pSpieler)
        {
            spieler = pSpieler;
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
