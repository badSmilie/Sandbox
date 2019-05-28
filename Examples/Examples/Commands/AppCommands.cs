using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Examples
{
    class AppCommands
    {
        private static ICommand exit = new ExitCommand();
        private static ICommand exitRouted = new ExitCommandRouted();
        public static ICommand Exit
        {
            get
            {
                return exit;
            }
        }

        public static ICommand ExitRouted
        {
            get
            {
                return exitRouted;
            }
        }
    }
}
