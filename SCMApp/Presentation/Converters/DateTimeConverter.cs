using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace SCMApp.Presentation.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;
                string date = dateTime.ToString("dd.MM.yyyy");
                return date;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                DateTime dateTime;
                if (DateTime.TryParse(value.ToString(), out dateTime))
                {
                    return dateTime;
                }
                else
                    return null;
            }
            return string.Empty;
        }
    }
}
