using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    class SpielbrettViewModel : ISpielbrettViewModel
    {
        private readonly IReadOnlyList<IPlatz> plaetze;
        private readonly IReadOnlyList<IClickColumnCommand> klickSpalteCommands;
        private readonly IReadOnlyList<ISpalte> spalten;

        public SpielbrettViewModel(IReadOnlyList<PlatzViewModelDecorator> pPlaetze,
                              IReadOnlyList<IClickColumnCommand> pClickCommands,
                              IReadOnlyList<ISpalte> pSpalten)
        {
            if (pPlaetze == null) throw new ArgumentNullException("Plaetze");
            if (pClickCommands == null) throw new ArgumentNullException("clickSpaltenCommands");
            if (pSpalten == null) throw new ArgumentNullException("Spalten");

            plaetze = pPlaetze;
            klickSpalteCommands = pClickCommands;
            spalten = pSpalten;

            foreach (var platz in pPlaetze)
                platz.CellClicked += RaiseSpaltenCommandIfPossible;
        }

        private void RaiseSpaltenCommandIfPossible(IPlatz platz)
        {
            var correspondingColumn = spalten[platz.X];
            if (correspondingColumn.NextEmptyCell != platz)
                return;

            var targetCommand = klickSpalteCommands.First(command => command.SpaltenIndex == correspondingColumn.Index);
            if (targetCommand.CanExecute(null))
                targetCommand.Execute(null);
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
