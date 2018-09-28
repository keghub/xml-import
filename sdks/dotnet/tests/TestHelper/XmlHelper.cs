using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TestHelper
{
    public static class XmlHelper
    {
        public static XNamespace Namespace = @"http://educations.com/XmlImport";

        public static readonly IEqualityComparer<DateTime> DateEqualityComparer = new DateEqualityComparer();
        public static readonly IEqualityComparer<DateTime> TimeEqualityComparer = new TimeEqualityComparer();


        public static string ToXmlString<T>(this T obj)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public static T FromXmlString<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(xml))
            {
                var obj = serializer.Deserialize(sr);
                return (T) obj;
            }
        }

        public static XDocument ToXml<T>(this T obj)
        {
            var serializer = new XmlSerializer(typeof(T));

            var document = new XDocument();

            using (var writer = document.CreateWriter())
            {
                serializer.Serialize(writer, obj);
                return document;
            }
        }

        public static T FromXml<T>(XDocument document)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = document.CreateReader())
            {
                var obj = serializer.Deserialize(reader);
                return (T)obj;
            }
        }

        public static T RoundTrip<T>(this T obj)
        {
            return FromXml<T>(obj.ToXml());
        }
    }

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
