using System.Collections.Generic;
using System.ComponentModel;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    public interface ISpielViewModel : INotifyPropertyChanged
    {
        IReadOnlyList<ISpielerViewModel> SpielerViewModels { get; }
        ISpielbrettViewModel SpielbrettViewModel { get; }
        string Gewinnername { get; }
        void SpieleZug(ISpalte spalte);       
    }
}
