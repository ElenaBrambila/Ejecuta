using System;

namespace IntegramsaUltimate.Utilidades
{
    public static class FormatDatetime
    {
        public static DateTime GetDatetimeDefaultByString(string dateTime)
        {
            var dateString = ((dateTime != null) ? dateTime : DateTime.Today.ToString("dd/MM/yyyy")) +" 00:00:00";

            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            return date;
        }
    }
}