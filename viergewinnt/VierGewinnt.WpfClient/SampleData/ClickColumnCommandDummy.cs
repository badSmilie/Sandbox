using System;

namespace VierGewinnt.WpfClient.SampleData
{
    public class ClickColumnCommandDummy : IClickColumnCommand
    {
        private readonly int spaltenIndex;
        private readonly bool _canExecute;

        public ClickColumnCommandDummy(int pSpaltenIndex, bool canExecute)
        {
            spaltenIndex = pSpaltenIndex;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {

        }

        public event EventHandler CanExecuteChanged;

        public int SpaltenIndex
        {
            get { return spaltenIndex; }
        }
    }
}
