using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    public class Farbkonverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var farbe = value as Farbe;
            if (farbe != null)
            {
                return new SolidColorBrush(Color.FromRgb(farbe.Rot, farbe.Gruen, farbe.Blau));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
