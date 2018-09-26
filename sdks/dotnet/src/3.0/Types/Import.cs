using System;
using System.Xml.Serialization;

namespace EMG.XML
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    [XmlRoot("import", Namespace = "http://educations.com/XmlImport", IsNullable = false)]
    public class Import
    {
        [XmlElement("provider")]
        public Provider[] Providers { get; set; }

        [XmlAttribute("version")]
        public decimal Version { get; set; } = 3.0m;
    }
}