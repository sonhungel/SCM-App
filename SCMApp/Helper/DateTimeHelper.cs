using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
