using System;
using System.Collections.Generic;
using System.Linq;
using static VierGewinntCore.Spiel;

namespace VierGewinntCore
{
    public class Spalte : Linie, ISpalte
    {
        private readonly int index;
        public Spalte(int pIndex, IReadOnlyList<IPlatz> pPlaetze) : base(pPlaetze)
        {
            index = pIndex;
        }

        public void LasseSpielsteinFallen(Spielstein spielstein)
        {
            for (int i = Plaetze.Count -1; i >= 0; i--)
            {
                if (Plaetze[i].Spielstein == null)
                {
                    Plaetze[i].Spielstein = spielstein;
                    return;
                }
            }

            throw new InvalidOperationException("Die Spalte ist bereits voll"); 
        }

        public bool IstSpalteVoll
        {
            get
            {
                return Plaetze.All(platz => platz.Spielstein != null);
            }
        }

        public bool IsFull
        {
            get { return Plaetze.All(platz => platz.Spielstein != null); }
        }

        public int Index
        {
            get { return index; }
        }

        public IPlatz NextEmptyCell
        {
            get { return Plaetze.FirstOrDefault(platz => platz.Spielstein == null); }
        }
    }
}