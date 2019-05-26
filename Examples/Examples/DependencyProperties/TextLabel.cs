using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Examples
{
    class TextLabel : FrameworkElement
    {
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly DependencyProperty FontSizeProperty;

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty;

        static TextLabel()
        {
            // Using a DependencyProperty as the backing store for FontSizeProperty.  This enables animation, styling, binding, etc...
            FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(TextLabel), 
                new FrameworkPropertyMetadata(11.0, FrameworkPropertyMetadataOptions.AffectsMeasure), new ValidateValueCallback(FontSizeValidator));

            // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextLabel), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsMeasure));
        }

        private static bool FontSizeValidator(object value)
        {
            return (double)value > 0;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            FormattedText txt = GetFormattedText();
            return new Size(txt.Width + 5, txt.Height + 5);
        }

        private FormattedText GetFormattedText()
        {
            return new FormattedText(this.Text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Arial"), this.FontSize, Brushes.Black);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            drawingContext.DrawRectangle(Brushes.LightGray, null, new Rect(this.RenderSize));
            FormattedText txt = GetFormattedText();
            drawingContext.DrawText(txt, new Point(2.5, 2.5)); 
        }
    }
}
