using System.Globalization;

namespace SCMApp.Helper
{
    public class MoneyHelper
    {
        public static string IntToStandardMoneyStringWithTail(int? money)
        {
            if(!money.HasValue)
                return string.Empty;

            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return string.Format(cul, "{0:c}", money);
        }

        public static string IntToStandardMoneyString (int? money)
        {
            if (!money.HasValue)
                return string.Empty;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return money.Value.ToString("#,###", cul.NumberFormat);
        }

        public static string IntToStandardMoneyStringWithTail(long? money)
        {
            if (!money.HasValue)
                return string.Empty;

            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return string.Format(cul, "{0:c}", money);
        }

        public static string IntToStandardMoneyStringWithTail(double? money)
        {
            if (!money.HasValue)
                return string.Empty;

            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return string.Format(cul, "{0:c}", money);
        }
    }
}
