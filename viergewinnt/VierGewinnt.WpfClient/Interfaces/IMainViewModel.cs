using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        List<IMenuCommand> MenuCommands  { get; }
        void NeuesSpiel();
    }
}
