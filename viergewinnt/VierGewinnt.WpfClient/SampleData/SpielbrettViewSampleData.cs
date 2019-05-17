using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VierGewinntCore;

namespace VierGewinnt.WpfClient.SampleData
{
    public class SpielbrettViewSampleData : ISpielbrettViewModel
    {
        private IReadOnlyList<IPlatz> plaetze;
        private IReadOnlyList<IClickColumnCommand> klickSpalteCommands;

        public SpielbrettViewSampleData()
        {
            // Plätze initialisieren
            var plätze = new IPlatz[7][];

            for (var i = 0; i < 7; i++)
            {
                plätze[i] = new IPlatz[6];
                for (var j = 0; j < 6; j++)
                {
                    plätze[i][j] = new PlatzFactory().Erstelle(i, j);
                }
            }

            for (var i = 0; i < 7; i++)
            {
                plätze[i][4].Spielstein = new Spielstein(new Farbe(128, 0, 0), "Foo");
            }

            for (var i = 0; i < 7; i++)
            {
                plätze[i][5].Spielstein = new Spielstein(new Farbe(0, 0, 128), "Bar");
            }

            plaetze = plätze.SelectMany(innererArray => innererArray)
                            .ToList();

            // Spaltenkommandos initialisieren
            var klickSpalteKommandos = new List<IClickColumnCommand>();
            for (var i = 0; i < 7; i++)
            {
                var canExecute = i != 0 && i != 1;
                klickSpalteKommandos.Add(new ClickColumnCommandDummy(i, canExecute));
            }
            klickSpalteCommands = klickSpalteKommandos;
        }
        public IReadOnlyList<IPlatz> Plaetze
        {
            get { return plaetze; }
        }

        public IReadOnlyList<IClickColumnCommand> KlickSpalteCommands
        {
            get { return klickSpalteCommands; }
        }
    }
}
