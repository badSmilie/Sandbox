using System.Windows.Input;

namespace VierGewinnt.WpfClient
{
    public interface IClickColumnCommand : ICommand
    {
        int SpaltenIndex { get; }
    }
}