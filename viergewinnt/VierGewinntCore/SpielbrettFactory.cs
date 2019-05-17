using System;
using System.Collections.Generic;

namespace VierGewinntCore
{
    public class SpielbrettFactory
    {
        private IPlatzFactory platzfactory { get; }
        public SpielbrettFactory(IPlatzFactory platzFactory)
        {
            platzfactory = platzFactory;
        }

        public Spielbrett Create(int pReihenAnzahl, int pSpaltenAnzahl)
        {
            if (pSpaltenAnzahl < 2)
            {
                throw new ArgumentOutOfRangeException("spaltenAnzahl", "Die Spaltenanzahl darf nicht kleiner als 2 sein");
            }

            if (pReihenAnzahl < 2)
            {
                throw new ArgumentOutOfRangeException("reihenAnzahl", "Die Reihenanzahl darf nicht kleiner als 2 sein");
            }
            var plaetze = new IPlatz[pSpaltenAnzahl][];

            for (var i = 0; i < pSpaltenAnzahl; i++)
            {
                plaetze[i] = new IPlatz[pReihenAnzahl];
                for (var j = 0; j < pReihenAnzahl; j++)
                {
                    plaetze[i][j] = platzfactory.Erstelle(i, j);
                }
            }

            var spalten = new List<Spalte>();
            for (var i = 0; i < pSpaltenAnzahl; i++)
            {
                var spaltenPlaetze = new List<IPlatz>();
                for (var j = 0; j < pReihenAnzahl; j++)
                {
                    spaltenPlaetze.Add(plaetze[i][j]);
                }
                spalten.Add(new Spalte(i, spaltenPlaetze));
            }

            var reihen = new List<Reihe>();
            for (int j = 0; j < pReihenAnzahl; j++)
            {
                var reihenPlaetze = new List<IPlatz>();
                for (var i = 0; i < pSpaltenAnzahl; i++)
                {
                    reihenPlaetze.Add(plaetze[i][j]);
                }

                reihen.Add(new Reihe(reihenPlaetze)); 
            }

            // links oben nach rechte unten
            var diagonalen = new List<Diagonale>();
            for (var i = 0; i < pSpaltenAnzahl; i++)
            {
                var spaltenIndex = i;
                var reihenIndex = 0;
                var diagonalenPlaetze = new List<IPlatz>();
                while(spaltenIndex < pSpaltenAnzahl && reihenIndex < pReihenAnzahl)
                {
                    diagonalenPlaetze.Add(plaetze[spaltenIndex][reihenIndex]);
                    spaltenIndex++;
                    reihenIndex++;
                }

                if (diagonalenPlaetze.Count >= 4)
                {
                    diagonalen.Add(new Diagonale(diagonalenPlaetze));
                }
            }

            for (var j = 0; j < pReihenAnzahl; j++)
            {
                var reihenIndex = j;
                var spaltenIndex = 0;
                var diagonalenPlaetze = new List<IPlatz>();
                while (spaltenIndex < pSpaltenAnzahl && reihenIndex < pReihenAnzahl)
                {
                    diagonalenPlaetze.Add(plaetze[spaltenIndex][reihenIndex]);
                    spaltenIndex++;
                    reihenIndex++;
                }

                if (diagonalenPlaetze.Count >= 4)
                {
                    diagonalen.Add(new Diagonale(diagonalenPlaetze));
                }
            }

            // rechts oben nach links unten

            for (var i = 0; i < pSpaltenAnzahl; i++)
            {
                var spaltenIndex = i;
                var reihenIndex = 0;
                var diagonalenPlaetze = new List<IPlatz>();
                while (spaltenIndex >= 0 && reihenIndex < pReihenAnzahl)
                {
                    diagonalenPlaetze.Add(plaetze[spaltenIndex][reihenIndex]);
                    spaltenIndex--;
                    reihenIndex++;
                }

                if (diagonalenPlaetze.Count >= 4)
                {
                    diagonalen.Add(new Diagonale(diagonalenPlaetze)); 
                }
            }

            for (var j = 0; j < pReihenAnzahl; j++)
            {
                var reihenIndex = j;
                var spaltenIndex = pSpaltenAnzahl -1;
                var diagonalenPlaetze = new List<IPlatz>();
                while (spaltenIndex >= 0 && reihenIndex < pReihenAnzahl)
                {
                    diagonalenPlaetze.Add(plaetze[spaltenIndex][reihenIndex]);
                    spaltenIndex--;
                    reihenIndex++;
                }

                if (diagonalenPlaetze.Count >= 4)
                {
                    diagonalen.Add(new Diagonale(diagonalenPlaetze));
                }
            }

            return new Spielbrett(plaetze,reihen,spalten,diagonalen);
        }
    }
}
