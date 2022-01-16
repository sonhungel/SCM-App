using SCMApp.Constants;
using SCMApp.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SCMApp.Presentation.Converters
{
    public class MoneyConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && targetType == typeof(string) && value.ToString() == "0")
            {
                return string.Empty;
            }

            if (value != null&& value is int && targetType == typeof(string))
            {
                return MoneyHelper.IntToStandardMoneyString((int)value);
            }

            if (value != null && value is string && (targetType == typeof(int)|| targetType == typeof(int?)))
            {
                string valueString = value.ToString();
                valueString = valueString.Replace(".", "");
                valueString = valueString.Replace(" ", "");
                valueString = valueString.Replace("₫", "");

                int result = 0;
                if (int.TryParse(valueString, out result))
                {
                    return result;
                }
                return 0;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && targetType == typeof(string) && value.ToString() == "0")
            {
                return string.Empty;
            }

            if (value != null && value is int && targetType == typeof(string))
            {
                return MoneyHelper.IntToStandardMoneyString((int)value);
            }

            if (value != null && value is string && (targetType == typeof(int) || targetType == typeof(int?)))
            {
                string valueString = value.ToString();
                valueString = valueString.Replace(".", "");
                valueString = valueString.Replace(" ", "");
                valueString = valueString.Replace("₫", "");

                int result = 0;
                if (int.TryParse(valueString, out result))
                {
                    return result;
                }
                return 0;
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
