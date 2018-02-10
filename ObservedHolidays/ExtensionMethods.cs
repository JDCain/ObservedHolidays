using System;
using System.Collections.Generic;
using System.Linq;

namespace ObservedHolidays
{
    public static class ExtensionMethods
    {
        private static readonly HolidayData _defaultHolidays = new HolidayData()
        {
            Static = new List<StaticHoliday>
            {
                new StaticHoliday { Holiday = Holiday.NewYearsDay, Month = 1, Day = 1 },
                new StaticHoliday { Holiday = Holiday.IndpendenceDay, Month = 7, Day = 4 }
            },
            Variable = new List<VariableHoliday>
            {
                new VariableHoliday { Holiday = Holiday.ThanksgivingDay, DayOfWeek = DayOfWeek.Thursday, Month = 11, Position = 3 },
                new VariableHoliday { Holiday = Holiday.MartinLutherKingDay, DayOfWeek = DayOfWeek.Monday, Month = 1, Position = 2 },
                new VariableHoliday { Holiday = Holiday.MemorialDay, DayOfWeek = DayOfWeek.Monday, Month = 5, Reverse = true, Position = 0 }
            }
        };

        
        public static Holiday ObservedHoliday(this DateTime date, HolidayData holidayData = null)
        {
            if (holidayData == null)
            {
                holidayData = _defaultHolidays;
            }
            var result = Holiday.None;

            if (!date.IsWeekend())
            {
                foreach (var staticHolidayItem in holidayData.Static)
                {            
                    var holidayDateTime = date.DayOfYear == 365 ? new DateTime(date.AddYears(1).Year, staticHolidayItem.Month, staticHolidayItem.Day) : new DateTime(date.Year, staticHolidayItem.Month, staticHolidayItem.Day);
                    if ((date == holidayDateTime)
                        || (date.DayOfWeek == DayOfWeek.Monday && date.AddDays(-1) == holidayDateTime )
                        || (date.DayOfWeek == DayOfWeek.Friday && date.AddDays(1) == holidayDateTime))
                    {
                        result = staticHolidayItem.Holiday;
                        break;
                    }
                }
                if (result == Holiday.None)
                {
                    foreach (var variableHoliday in holidayData.Variable)
                    {
                        var dayList = Enumerable.Range(1, DateTime.DaysInMonth(date.Year, variableHoliday.Month))
                            .Where(x => new DateTime(date.Year, variableHoliday.Month, x).DayOfWeek ==
                                        variableHoliday.DayOfWeek);

                        var day = variableHoliday.Reverse
                            ? dayList.OrderByDescending(x => x).ElementAt(variableHoliday.Position)
                            : dayList.ElementAt(variableHoliday.Position); 

                            var holiday = new DateTime(date.Year, variableHoliday.Month, day);
                        if (holiday == date)
                        {
                            result = variableHoliday.Holiday;
                            break;
                        }
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

    }

}