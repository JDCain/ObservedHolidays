using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObservedHolidays.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ObservedHoliday_01012018()
        {
            Assert.IsTrue(new DateTime(2018, 1, 1).ObservedHoliday() == Holiday.NewYearsDay);
        }
        [TestMethod]
        public void ObservedHoliday_12312010()
        {
            Assert.IsTrue(new DateTime(2010, 12, 31).ObservedHoliday() == Holiday.NewYearsDay);
        }
        [TestMethod]
        public void ObservedHoliday_01022012()
        {
            Assert.IsTrue(new DateTime(2012, 1, 2).ObservedHoliday() == Holiday.NewYearsDay);
        }
        [TestMethod]
        public void ObservedHoliday_07042018()
        {
            Assert.IsTrue(new DateTime(2018, 7, 4).ObservedHoliday() == Holiday.IndpendenceDay);
        }
        [TestMethod]
        public void ObservedHoliday_07032015()
        {
            Assert.IsTrue(new DateTime(2015, 7, 3).ObservedHoliday() == Holiday.IndpendenceDay);
        }
        [TestMethod]
        public void ObservedHoliday_07052010()
        {
            Assert.IsTrue(new DateTime(2010, 7, 5).ObservedHoliday() == Holiday.IndpendenceDay);
        }

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
