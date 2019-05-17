using System;
using System.Collections.Generic;
using System.Linq;

namespace VierGewinntCore
{
    public class Spielbrett
    {
        private readonly IReadOnlyList<IReadOnlyList<IPlatz>> plaetze;
        private readonly IReadOnlyList<Reihe> reihen;
        private readonly IReadOnlyList<Spalte> spalten;
        private readonly IReadOnlyList<Diagonale> diagonalen;
        private IReadOnlyList<Linie> spielbrettlinien;

        public Spielbrett(IReadOnlyList<IReadOnlyList<IPlatz>> pPlaetze, IReadOnlyList<Reihe> pReihen, IReadOnlyList<Spalte> pSpalten, IReadOnlyList<Diagonale> pDiagonalen)
        {
            plaetze = pPlaetze;
            reihen = pReihen;
            spalten = pSpalten;
            diagonalen = pDiagonalen;
            spielbrettlinien = reihen.Cast<Linie>().Concat(spalten).Concat(diagonalen).ToList();
        }

        public IReadOnlyList<IReadOnlyList<IPlatz>> Plaetze => plaetze;

        public IReadOnlyList<Reihe> Reihen => reihen;

        public IReadOnlyList<Spalte> Spalten => spalten;

        public IReadOnlyList<Diagonale> Diagonalen => diagonalen;
        public string BestimmeGewinnername()
        {
            foreach (Linie line in spielbrettlinien)
            {
                string gewinnername = line.UeberpruefeObVierInEinerReihe();

                if (gewinnername != null)
                {
                    return gewinnername;
                }
            }

            return null;
        }
    }
}
