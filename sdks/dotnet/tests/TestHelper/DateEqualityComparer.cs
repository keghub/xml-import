using System;
using System.Collections.Generic;

namespace TestHelper {
    public class DateEqualityComparer : IEqualityComparer<DateTime>, IEqualityComparer<DateTime?>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            return x.Year == y.Year && x.Month == y.Month && x.Day == y.Day;
        }

        public int GetHashCode(DateTime obj)
        {
            return obj.Year.GetHashCode() ^ obj.Month.GetHashCode() ^ obj.Day.GetHashCode();
        }

        public bool Equals(DateTime? x, DateTime? y)
        {
            if (x.HasValue != y.HasValue)
                return false;

            return !x.HasValue || Equals(x.Value, y.Value);
        }

        public int GetHashCode(DateTime? obj)
        {
            if (!obj.HasValue) return default(DateTime?).GetHashCode();

            return obj.Value.GetHashCode();
        }

    }
}