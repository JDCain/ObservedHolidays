using System;

namespace ObservedHolidays
{
    public static class ExtensionMethods
    {
        public static Holiday ObservedHoliday(this DateTime date)
        {
            

            return Holiday.None;
        }

        public static bool IsWeekend(this DateTime date)
        {        
            return date.DayOfWeek == DayOfWeek.Sunday 
                || date.DayOfWeek == DayOfWeek.Saturday;
        }

        public static DateTime ShiftForObserved(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    date = date.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    date = date.AddDays(-1);
                    break;
            }
            return date;
        }

    }

}