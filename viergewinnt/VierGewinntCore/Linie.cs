using System.Collections.Generic;

namespace VierGewinntCore
{
    public abstract class Linie
    {
        private readonly IReadOnlyList<IPlatz> plaetze;

        protected Linie(IReadOnlyList<IPlatz> pPlaetze)
        {
            if (pPlaetze != null)
            {
                plaetze = pPlaetze;
            }
        }

        public IReadOnlyList<IPlatz> Plaetze
        {
            get
            {
                return plaetze;
            }
        }

        public string UeberpruefeObVierInEinerReihe()
        {
            var counter = 0;
            string spielername = null;

            foreach (var platz in plaetze)
            {
                var spielstein = platz.Spielstein;
                if (spielstein == null)
                {
                    spielername = null;
                    counter = 0;
                    continue;
                }

                if (spielername != spielstein.SpielerName)
                {
                    spielername = spielstein.SpielerName;
                    counter = 1;
                    continue;
                }

                counter++;
                if (counter >= 4)
                {
                    return spielername;
                }
            }

            return null;
        }
    }
}
