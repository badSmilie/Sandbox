using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    public interface ISpielerViewModel
    {
        Spieler Spieler
        {
            get;
        }

        bool IstDran { get; set; }
    }
}
