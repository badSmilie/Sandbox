using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Examples
{
    class ExitCommandRouted : ICommand
    {

        public event EventHandler CanExecuteChanged;
        public static readonly RoutedEvent ExecuteEvent = EventManager.RegisterRoutedEvent("Execute", RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(ExitCommandRouted));
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RoutedEventArgs routedEventArgs = new RoutedEventArgs(ExecuteEvent, Keyboard.FocusedElement);
            Keyboard.FocusedElement.RaiseEvent(routedEventArgs);
        }

        public static void AddExecuteHandler(DependencyObject o, RoutedEventHandler handler)
        {
            ((UIElement)o).AddHandler(ExitCommandRouted.ExecuteEvent, handler);
        }

        public static void RemoveExecuteHandler(DependencyObject o, RoutedEventHandler handler)
        {
            ((UIElement)o).RemoveHandler(ExitCommandRouted.ExecuteEvent, handler);
        }
    }
}
