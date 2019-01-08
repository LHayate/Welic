using System;

namespace UseFul.Uteis
{
    public class DateRange
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public static DateRange Today(DateTime date)
        {
            DateRange range = new DateRange {Start = DateTime.Now};

            range.End = range.Start;

            return range;
        }

        public static DateRange Yesterday(DateTime date)
        {
            DateRange range = new DateRange {Start = DateTime.Now.AddDays(-1)};

            range.End = range.Start;

            return range;
        }

        public static DateRange ThisYear(DateTime date)
        {
            DateRange range = new DateRange {Start = new DateTime(date.Year, 1, 1)};

            range.End = range.Start.AddYears(1).AddSeconds(-1);

            return range;
        }

        public static DateRange LastYear(DateTime date)
        {
            DateRange range = new DateRange {Start = new DateTime(date.Year - 1, 1, 1)};

            range.End = range.Start.AddYears(1).AddSeconds(-1);

            return range;
        }

        public static DateRange ThisMonth(DateTime date)
        {
            DateRange range = new DateRange {Start = new DateTime(date.Year, date.Month, 1)};

            range.End = range.Start.AddMonths(1).AddSeconds(-1);

            return range;
        }

        public static DateRange LastMonth(DateTime date)
        {
            DateRange range = new DateRange {Start = new DateTime(date.Year, date.Month, 1).AddMonths(-1)};

            range.End = range.Start.AddMonths(1).AddSeconds(-1);

            return range;
        }

        public static DateRange ThisWeek(DateTime date)
        {
            DateRange range = new DateRange {Start = date.Date.AddDays(-(int) date.DayOfWeek)};

            range.End = range.Start.AddDays(7).AddSeconds(-1);

            return range;
        }

        public static DateRange LastWeek(DateTime date)
        {
            DateRange range = ThisWeek(date);

            range.Start = range.Start.AddDays(-7);
            range.End = range.End.AddDays(-7);

            return range;
        }

        public static DateRange TwoLastWeek(DateTime date)
        {
            DateRange range = ThisWeek(date);

            range.Start = range.Start.AddDays(-14);
            range.End = range.End.AddDays(-14);

            return range;
        }

        public static DateRange ThreeLastWeek(DateTime date)
        {
            DateRange range = ThisWeek(date);

            range.Start = range.Start.AddDays(-21);
            range.End = range.End.AddDays(-21);

            return range;
        }

        public static DateRange FourLastWeek(DateTime date)
        {
            DateRange range = ThisWeek(date);

            range.Start = range.Start.AddDays(-28);
            range.End = range.End.AddDays(-28);

            return range;
        }
    }
}