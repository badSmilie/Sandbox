using System.Collections.Generic;

namespace VierGewinnt.WpfClient
{
    public class BaseViewModel
    {
        private List<IMenuCommand> menuCommands;

        public List<IMenuCommand> MenuCommands
        {
            get
            {
                return menuCommands;
            }
            set
            {
                menuCommands = value;
            }
        }
        public BaseViewModel()
        {
            MenuCommands = new List<IMenuCommand>();
            MenuCommands.Add(new NeuesSpielCommand(MainViewModel.Instance, 0));
        }
    }
}