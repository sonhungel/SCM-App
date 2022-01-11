using System;

namespace SCMApp.Helper
{
    public static class DateTimeHelper
    {
        public static string DateTimeToStandardString(DateTime? dateTime)
        {
            if(dateTime != null)
                return dateTime.Value.ToString("dd/MM/yyyy");
            return string.Empty;
        }

        public static string DateTimeToYearMonthDay(DateTime? dateTime)
        {
            if (dateTime != null)
                return dateTime.Value.ToString("yyyy/MM/dd");
            return string.Empty;
        }
    }
}
