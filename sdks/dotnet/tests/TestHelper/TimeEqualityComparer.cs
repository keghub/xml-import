using System;
using System.Collections.Generic;

namespace TestHelper {
    public class TimeEqualityComparer : IEqualityComparer<DateTime>, IEqualityComparer<DateTime?>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            return x.Hour == y.Hour && x.Minute == y.Minute && x.Second == y.Second && x.Millisecond == y.Millisecond;
        }

        public int GetHashCode(DateTime obj)
        {
            return obj.Hour.GetHashCode() ^ obj.Minute.GetHashCode() ^ obj.Second.GetHashCode() ^ obj.Millisecond.GetHashCode();
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