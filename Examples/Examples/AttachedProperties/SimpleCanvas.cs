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
        [AttachedPropertyBrowsableForChildren]
        public static double GetTop(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentException("element");
            }
            return (double)element.GetValue(SimpleCanvas.TopProperty);
        }

        [AttachedPropertyBrowsableForChildren]
        public static void SetTop(UIElement element, double value)
        {
            if (element == null)
            {
                throw new ArgumentException("element");
            }
            element.SetValue(SimpleCanvas.TopProperty, value);
        }

        [AttachedPropertyBrowsableForChildren]
        public static double GetLeft(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentException("element");
            }
            return (double)element.GetValue(SimpleCanvas.LeftProperty);
        }

        [AttachedPropertyBrowsableForChildren]
        public static void SetLeft(UIElement element, double value)
        {
            if (element == null)
            {
                throw new ArgumentException("element");
            }
            element.SetValue(SimpleCanvas.LeftProperty, value);
        }

        public static readonly DependencyProperty TopProperty;
        public static readonly DependencyProperty LeftProperty;

        static SimpleCanvas()
        {
            // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
            TopProperty = DependencyProperty.RegisterAttached("Top", typeof(double),
                           typeof(SimpleCanvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

            // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
            LeftProperty = DependencyProperty.RegisterAttached("Left", typeof(double),
                           typeof(SimpleCanvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentMeasure));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size myDesiredSize = new Size();
            foreach(UIElement child in this.InternalChildren)
            {
                child.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                double width = GetLeft(child) + child.DesiredSize.Width;
                double height = GetTop(child) + child.DesiredSize.Height;
                myDesiredSize.Width = Math.Max(width, myDesiredSize.Width);
                myDesiredSize.Height = Math.Max(height, myDesiredSize.Height);
            }
            return myDesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Point location = new Point();
            foreach(UIElement child in this.InternalChildren)
            {
                location.X = GetLeft(child);
                location.Y = GetTop(child);
                child.Arrange(new Rect(location, child.DesiredSize));
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}
