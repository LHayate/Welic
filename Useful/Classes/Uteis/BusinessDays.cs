using System;

namespace UseFul.Uteis
{
    public static class BusinessDays
    {
        public static DateTime AddBusinessDays(this DateTime source, int businessDays)
        {
            int dayOfWeek = businessDays < 0
                ? ((int) source.DayOfWeek - 12) % 7
                : ((int) source.DayOfWeek + 6) % 7;

            switch (dayOfWeek)
            {
                case 6:
                    businessDays--;
                    break;
                case -6:
                    businessDays++;
                    break;
            }

            return source.AddDays(businessDays + (businessDays + dayOfWeek) / 5 * 2);
        }
    }
}