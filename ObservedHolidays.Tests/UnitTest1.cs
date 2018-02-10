using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObservedHolidays.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsWeekendTest()
        {
            Assert.IsTrue(new DateTime(2018, 2, 10).IsWeekend());
            Assert.IsTrue(new DateTime(2018, 2, 11).IsWeekend());
        }
        [TestMethod]
        public void ShiftForObservedTest()
        {
            Assert.IsTrue(new DateTime(2018, 2, 10).ShiftForObserved().DayOfWeek == DayOfWeek.Friday);
            Assert.IsTrue(new DateTime(2018, 2, 11).ShiftForObserved().DayOfWeek == DayOfWeek.Monday);
        }
        
    }
}
