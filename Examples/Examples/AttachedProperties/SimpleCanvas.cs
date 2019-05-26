using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Examples
{
    class SimpleCanvas : Panel
    {
        public static double GetLeft(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentException("element");
            }
            return (double)element.GetValue(SimpleCanvas.LeftProperty);
        }

        public static void SetLeft(UIElement element, double value)
        {
            if (element == null)
            {
                throw new ArgumentException("element");
            }
            element.SetValue(SimpleCanvas.LeftProperty, value);
        }

        public static readonly DependencyProperty LeftProperty;

        static SimpleCanvas()
        {
            // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
            LeftProperty = DependencyProperty.RegisterAttached("Left", typeof(double),
                           typeof(SimpleCanvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentMeasure));
        }
    }
}
