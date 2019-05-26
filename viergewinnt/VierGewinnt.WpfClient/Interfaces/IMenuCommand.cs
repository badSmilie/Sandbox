using System.Windows.Input;

namespace VierGewinnt.WpfClient
{
    public interface IMenuCommand : ICommand
    {
        string Name { get; }
        int SpaltenIndex { get; set; }
    }
}