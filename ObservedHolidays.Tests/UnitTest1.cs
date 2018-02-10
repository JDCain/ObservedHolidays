using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObservedHolidays.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ObservedHoliday_02092018()
        {
            Assert.IsTrue(new DateTime(2018, 2, 9).ObservedHoliday() == null);
        }
        [TestMethod]
        public void ObservedHoliday_01012018()
        {
            Assert.IsTrue(new DateTime(2018, 1, 1).ObservedHoliday().Holiday == "NewYearsDay");
        }
        [TestMethod]
        public void ObservedHoliday_01012011()
        {
            Assert.IsTrue(new DateTime(2011, 1, 1).ObservedHoliday() == null);
        }
        [TestMethod]
        public void ObservedHoliday_12312010()
        {
            Assert.IsTrue(new DateTime(2010, 12, 31).ObservedHoliday().Holiday == "NewYearsDay");
        }
        [TestMethod]
        public void ObservedHoliday_01022012()
        {
            Assert.IsTrue(new DateTime(2012, 1, 2).ObservedHoliday().Holiday == "NewYearsDay");
        }
        [TestMethod]
        public void ObservedHoliday_07042018()
        {
            Assert.IsTrue(new DateTime(2018, 7, 4).ObservedHoliday().Holiday == "IndpendenceDay");
        }
        [TestMethod]
        public void ObservedHoliday_07032015()
        {
            Assert.IsTrue(new DateTime(2015, 7, 3).ObservedHoliday().Holiday == "IndpendenceDay");
        }
        [TestMethod]
        public void ObservedHoliday_07052010()
        {
            Assert.IsTrue(new DateTime(2010, 7, 5).ObservedHoliday().Holiday == "IndpendenceDay");
        }
        [TestMethod]
        public void ObservedHoliday_11222018()
        {
            Assert.IsTrue(new DateTime(2018, 11, 22).ObservedHoliday().Holiday == "ThanksgivingDay");
        }
        [TestMethod]
        public void ObservedHoliday_05282018()
        {
            Assert.IsTrue(new DateTime(2018, 5, 28).ObservedHoliday().Holiday == "MemorialDay");
        }
        [TestMethod]
        public void ObservedHoliday_01212019()
        {
            Assert.IsTrue(new DateTime(2019, 1, 21).ObservedHoliday().Holiday == "MartinLutherKingDay");
        }
        [TestMethod]
        public void OverrideTest()
        {
            var newHolidays = new HolidayData()
            {
                Static = new List<StaticHoliday>
                {
                    new StaticHoliday { Holiday = "MexicanIndpendenceDay", Month = 9, Day = 15 }
                },
                Variable = new List<VariableHoliday>()
            };
            Assert.IsTrue(new DateTime(2015, 9, 15).ObservedHoliday(newHolidays).Holiday == "MexicanIndpendenceDay");
        }

        [TestMethod]
        public void IsWeekendTest()
        {
            Assert.IsTrue(new DateTime(2018, 2, 10).IsWeekend());
            Assert.IsTrue(new DateTime(2018, 2, 11).IsWeekend());
        }
        
    }
}
