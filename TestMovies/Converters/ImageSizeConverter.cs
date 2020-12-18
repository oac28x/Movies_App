using System;
using System.Globalization;
using Xamarin.Forms;

namespace TestMovies.Converters
{
    public class ImageSizeConverter : IValueConverter
    {
        public ImageSizeConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value * 1.5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0; // No need to convert back
        }
    }
}
