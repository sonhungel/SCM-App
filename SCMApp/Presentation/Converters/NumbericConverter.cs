using SCMApp.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SCMApp.Presentation.Converters
{
    public class NumbericConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && targetType == typeof(string) && value.ToString() == "0")
            {
                return string.Empty;
            }

            if (value != null && (targetType == typeof(int) || targetType == typeof(int?)))
            {
                int result = 0;
                if (int.TryParse((string)value, out result))
                {
                    return result;
                }
                return 0;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (targetType == typeof(int) || targetType == typeof(int?)))
            {
                int result = 0;
                if (int.TryParse((string)value, out result))
                {
                    return result;
                }
                return 0;
            }
            if (value != null && CheckValueIsHaveAnyAlphabet(value.ToString()))
            {
                return string.Empty;
            }
            return value;
        }

        private bool CheckValueIsHaveAnyAlphabet(string value)
        {
            var r = value.Where(x => !CommonConstants.Numberic.Contains(x)).ToList();
            return r.Count > 0;
        }
    }
}
