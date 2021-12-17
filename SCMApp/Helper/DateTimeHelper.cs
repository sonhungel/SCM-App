using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Helper
{
    public static class DateTimeHelper
    {
        public static string DateTimeToStandardString(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }
    }
}
