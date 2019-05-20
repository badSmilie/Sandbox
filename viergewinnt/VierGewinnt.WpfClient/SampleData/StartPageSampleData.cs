using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VierGewinntCore;

namespace VierGewinnt.WpfClient.SampleData
{
    public class StartPageSampleData : IStartPageViewModel
    {
        private ICommand _starteSpielCommand;
        private readonly IList<ICommand> _farbenCommands;
        private Farbe _farbeSpielerA;
        private Farbe _farbeSpielerB;
        public StartPageSampleData()
        {
            _starteSpielCommand = new StartSpielCommand(this);
            _farbenCommands = new List<ICommand>();
            _farbenCommands.Add(new FarbenCommand(new Farbe(222, 183, 26, "/VierGewinnt.WpfClient;component/Bilder/rosa.png"), 0, this));
            _farbenCommands.Add(new FarbenCommand(new Farbe(62, 203, 119, "/VierGewinnt.WpfClient;component/Bilder/blau.png"), 1, this));
            _farbenCommands.Add(new FarbenCommand(new Farbe(236, 15, 208, "/VierGewinnt.WpfClient;component/Bilder/gelb.png"), 2, this));
            FarbeSpielerA = ((FarbenCommand)_farbenCommands[0]).Farbe;
            FarbeSpielerB = ((FarbenCommand)_farbenCommands[1]).Farbe;
        }

        public string SpielerNameA { get { return "Spieler A"; } set => throw new NotImplementedException(); }
        public string SpielerNameB { get { return "Spieler B"; } set => throw new NotImplementedException(); }
        
        public ICommand StarteSpielCommand
        {
            get
            {
                return _starteSpielCommand;
            }
        }

        public IList<ICommand> FarbenCommands { get => _farbenCommands; }
        public Farbe FarbeSpielerA { get => _farbeSpielerA; set => _farbeSpielerA = value; }
        public Farbe FarbeSpielerB { get => _farbeSpielerB; set => _farbeSpielerB = value; }

        public void SetzeFarbe(Farbe farbe)
        {

        }
        public void StarteSpiel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
