using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Examples
{
    class SimpleButton : ContentControl
    {
        public static readonly RoutedEvent ClickEvent;

        static SimpleButton()
        {
            ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SimpleButton));
            // vorhandene verwenden
            // ClickEvent = ButtonBase.ClickEvent.AddOwner(typeof(SimpleButton));
        }

        public event RoutedEventHandler Click
        {
            add
            {
                AddHandler(ClickEvent, value);
            }
            remove
            {
                RemoveHandler(ClickEvent, value);
            }
        }

        protected virtual void OnClick()
        {
            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            e.Handled = true;
            OnClick();
        }
    }
}
