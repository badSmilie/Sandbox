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
    class PlatzViewModelDecorator : IPlatz, INotifyPropertyChanged
    {
        private readonly IPlatz platz;
        public event Action<IPlatz> CellClicked;
        public Spielstein Spielstein
        {
            get
            {
                return platz.Spielstein;
            }
            set
            {
                if (platz.Spielstein != value)
                {
                    platz.Spielstein = value;
                    OnPropertyChanged();
                }
            }
        }
        public int X { get => platz.X; set => platz.X = value; }
        public int Y { get => platz.Y; set => platz.Y = value; }

        public PlatzViewModelDecorator(IPlatz pPlatz)
        {
            platz = pPlatz;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string property = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
