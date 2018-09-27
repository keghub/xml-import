using System.Xml.Serialization;

namespace EMG.XML {
    [XmlType("Institute", Namespace = "http://educations.com/XmlImport")]
    public class InstituteNode
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlArray("locations")]
        [XmlArrayItem("location")]
        public LocationNode[] Locations { get; set; }

        [XmlArray("educations")]
        [XmlArrayItem("education")]
        public EducationNode[] Educations { get; set; }
    }
}