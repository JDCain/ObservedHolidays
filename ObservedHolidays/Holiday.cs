using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObservedHolidays
{
    public enum Holiday
    {
        None,
        NewYearsDay,
        MartinLutherKingDay,
        IndpendenceDay,
        ThanksgivingDay,
        MemorialDay
    }

//    public class Holiday : Enumeration
//    {
//        public static Holiday None = new Holiday(1, "None");
//        public static Holiday NewYearsDay = new Holiday(2, "NewYearsDay");
//        public static Holiday MartinLutherKingDay = new Holiday(3, "MartinLutherKingDay");
//        public static Holiday IndpendenceDay = new Holiday(4, "IndpendenceDay");
//        public static Holiday ThanksgivingDay = new Holiday(5, "ThanksgivingDay");
//        public static Holiday MemorialDay = new Holiday(6, "MemorialDay");

//        protected Holiday() { }

//        public Holiday(int id, string name)
//            : base(id, name)
//        {
//        }

//        public static IEnumerable<Holiday> List()
//        {
//            return new[] { None, NewYearsDay, MartinLutherKingDay, IndpendenceDay, ThanksgivingDay, MemorialDay };
//        }

//    }

//    public abstract class Enumeration : IComparable
//    {
//        public string Name { get; private set; }
//        public int Id { get; private set; }

//        protected Enumeration()
//        {
//        }

//        protected Enumeration(int id, string name)
//        {
//            Id = id;
//            Name = name;
//        }

//        public override string ToString()
//        {
//            return Name;
//        }

//        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
//        {
//            var type = typeof(T);
//            var fields = type.GetTypeInfo().GetFields(BindingFlags.Public |
//                                                      BindingFlags.Static |
//                                                      BindingFlags.DeclaredOnly);
//            foreach (var info in fields)
//            {
//                var instance = new T();
//                if (info.GetValue(instance) is T locatedValue)
//                {
//                    yield return locatedValue;
//                }
//            }
//        }

//        public override bool Equals(object obj)
//        {
//            if (!(obj is Enumeration otherValue))
//            {
//                return false;
//            }
//            var typeMatches = GetType() == obj.GetType();
//            var valueMatches = Id.Equals(otherValue.Id);
//            return typeMatches && valueMatches;
//        }

//        public int CompareTo(object other)
//        {
//            return Id.CompareTo(((Enumeration)other).Id);
//        }

//        public override int GetHashCode()
//        {
//            throw new NotImplementedException();
//        }
//    }
}