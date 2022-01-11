using SCMApp.Constants.Enum;
using SCMApp.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace SCMApp.Presentation.Converters
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<TimeFilterEnum>)
            {
                var listEnum = (List<TimeFilterEnum>)value;
                List<string> result = new List<string>();
                listEnum.ForEach(e => result.Add(EnumHelper.GetDisplayValue(e)));
                return result;
            }
            if(value is string)
            {
                switch (value)
                {
                    case "Lọc theo Tuần":
                        return TimeFilterEnum.Week;
                    case "Lọc theo Tháng":
                        return TimeFilterEnum.Month;
                    case "Lọc theo Năm":
                        return TimeFilterEnum.Year;
                }
            }    
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                switch (value)
                {
                    case "Lọc theo Tuần":
                        return TimeFilterEnum.Week;
                    case "Lọc theo Tháng":
                        return TimeFilterEnum.Month;
                    case "Lọc theo Năm":
                        return TimeFilterEnum.Year;
                }
            }
            return value;
        }
    }
}
