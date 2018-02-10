using System;
using System.Collections.Generic;

namespace ObservedHolidays
{
    public class StaticHolidayItem
    {
        public Holiday Holiday { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }

    public static class ExtensionMethods
    {
        private static IEnumerable<StaticHolidayItem> _staticHolidays => new List<StaticHolidayItem>()
        {
            new StaticHolidayItem { Holiday = Holiday.NewYearsDay, Month = 1, Day = 1 },
            new StaticHolidayItem { Holiday = Holiday.IndpendenceDay, Month = 7, Day = 4 }
        };
        public static Holiday ObservedHoliday(this DateTime date)
        {
            var result = Holiday.None;
            foreach (var staticHolidayItem in _staticHolidays)
            {            
                if (!date.IsWeekend())
                {
                    var holidayDateTime = date.DayOfYear == 365 ? new DateTime(date.AddYears(1).Year, staticHolidayItem.Month, staticHolidayItem.Day) : new DateTime(date.Year, staticHolidayItem.Month, staticHolidayItem.Day);
                    if ((date == holidayDateTime)
                        || (date.DayOfWeek == DayOfWeek.Monday && date.AddDays(-1) == holidayDateTime )
                        || (date.DayOfWeek == DayOfWeek.Friday && date.AddDays(1) == holidayDateTime))
                    {
                        result = staticHolidayItem.Holiday;
                    }
                }
            }
            return result;
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

        public static DateTime ShiftIntoWeekend(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    date = date.AddDays(1);
                    break;
                case DayOfWeek.Monday:
                    date = date.AddDays(-1);
                    break;
            }
            return date;
        }

    }

}