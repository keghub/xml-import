using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using NUnit.Framework;

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
            return FromXml<T>(ToXml(obj));
        }


        public static void ValidateDocument(this XmlSchemaSet schema, XDocument document)
        {
            var errors = new List<Exception>();
           
            document.Validate(schema, (o, e) => { errors.Add(e.Exception); });

            if (errors.Count > 0)
            {
                throw new AggregateException("An error occurred while validating the document", errors);
            }
        }
    }
}
