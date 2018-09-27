using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    [XmlRoot("informationUpdateBatch", Namespace = "http://educations.com/XmlImport", IsNullable = false)]
    public class Import
    {
        [XmlAttribute("version")]
        public decimal Version { get; set; } = 3.0m;

        [XmlElement("institute")]
        public InstituteNode[] Institutes { get; set; }
    }
}
