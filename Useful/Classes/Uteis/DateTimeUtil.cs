using System;

namespace UseFul.Uteis
{
    public static class DateTimeUtil
    {
        public static bool IsBusinessDay(this DateTime date)
        {
            return
                date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday;
        }

        public static DateTime PrimeiroDiaMes(DateTime date)
        {
            DateTime today = date;
            return new DateTime(today.Year, today.Month, 1);
        }

        public static DateTime UltimoDiaMes(DateTime date)
        {
            DateTime today = date;
            DateTime first = new DateTime(today.Year, today.Month, 1);
            return first.AddMonths(1).AddDays(-1);
        }

        public static DateTime UltimoDiaProximoMes(DateTime date)
        {
            DateTime today = date.AddMonths(1);
            DateTime first = new DateTime(today.Year, today.Month, 1);
            return first.AddMonths(1).AddDays(-1);
        }
    }
}