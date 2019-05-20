using System.Collections.Generic;
using System.ComponentModel;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    public interface IStartPageViewModel : INotifyPropertyChanged
    {
        string SpielerNameA { get; set; }
        string SpielerNameB { get; set; }
        void StarteSpiel();
        void SetzeFarbe(Farbe farbe);
    }
}
