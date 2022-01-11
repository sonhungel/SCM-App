using System;
using System.Globalization;
using System.Windows.Data;

namespace SCMApp.Presentation.Converters
{
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result;
            if(value is string && int.TryParse((string)value, out result))
            {
               return result;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result;
            if (value is string && int.TryParse((string)value, out result))
            {
                return result;
            }
            return value;
        }
    }
}
