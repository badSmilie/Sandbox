using System;

namespace VierGewinntCore
{
    public class Spielstein
    {
        private readonly Farbe farbe;
        private readonly string spielerName;

        public Spielstein(Farbe pFarbe, string pSpielerName)
        {
            farbe = pFarbe ?? throw new ArgumentNullException("farbe");
            spielerName = pSpielerName ?? throw new ArgumentNullException("spielerName");
        }

        public Farbe Farbe => farbe;

        public string SpielerName => spielerName;
    }
}
