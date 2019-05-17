using System.Collections.Generic;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    public interface ISpielbrettViewModel
    {
        IReadOnlyList<IPlatz> Plaetze { get; }
        IReadOnlyList<IClickColumnCommand> KlickSpalteCommands { get; }
    }
}