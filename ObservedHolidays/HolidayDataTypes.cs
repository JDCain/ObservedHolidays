﻿using System;
using System.Collections.Generic;

namespace ObservedHolidays
{
    public class HolidayData
    {
        public IEnumerable<StaticHoliday> Static { get; set; }
        public IEnumerable<VariableHoliday> Variable { get; set; }
    }
    public class StaticHoliday : IHoliday
    {
        public string Holiday { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
    public class VariableHoliday : IHoliday
    {
        public string Holiday { get; set; }
        public int Month { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Position { get; set; }
        public bool Reverse { get; set; }
    }
}