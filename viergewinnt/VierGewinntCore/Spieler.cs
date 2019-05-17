using System.Collections.Generic;
using static VierGewinntCore.Spiel;

namespace VierGewinntCore
{
    public class Spieler
    {
        private readonly IList<Spielstein> spielsteine;
        private readonly string name;
        public Farbe Farbe { get; }

        public string Name => name;
        public IList<Spielstein> Spielsteine => spielsteine;

        

        public Spieler(string pName, IList<Spielstein> pSpielsteine, Farbe pFarbe)
        {
            if (pSpielsteine != null)
            {
                name = pName;
                spielsteine = pSpielsteine;
                Farbe = pFarbe;
            }           
        }

        public void SpieleZug(ISpalte pSpalte)
        {
            if (pSpalte != null)
            {
                Spielstein obersteSpielstein = spielsteine[0];
                spielsteine.RemoveAt(0);
                pSpalte.LasseSpielsteinFallen(obersteSpielstein);
            }
        }
    }
}
