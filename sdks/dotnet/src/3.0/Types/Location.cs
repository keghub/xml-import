using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("Location", Namespace = "http://educations.com/XmlImport")]
    public class Location
    {
        [XmlAttribute("uniqueIdentifier")]
        public string UniqueIdentifier { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("hasAccomodation")]
        public bool HasAccommodation { get; set; }

        [XmlAttribute("IsFoodProvided")]
        public bool IsFoodProvided { get; set; }

        [XmlElement("place")]
        public string Place { get; set; }

        [XmlElement("visitingAddress")]
        public Address VisitingAddress { get; set; }

        [XmlElement("mailingAddress")]
        public Address MailingAddress { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("residentialInformation")]
        public string ResidentialInformation { get; set; }

        [XmlElement("contacts")]
        public LocationContacts Contacts { get; set; }

        [XmlElement("coordinates")]
        public Coordinates Coordinates { get; set; }
    }

    [XmlType("Address", Namespace = "http://educations.com/XmlImport")]
    public class Address
    {
        [XmlAttribute("street")]
        public string Street { get; set; }

        [XmlAttribute("co")]
        public string CareOf { get; set; }

        [XmlAttribute("city")]
        public string City { get; set; }

        [XmlAttribute("zip")]
        public string ZipCode { get; set; }

        [XmlAttribute("country")]
        public string Country { get; set; }
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class LocationContacts
    {
        [XmlAttribute("telephone")]
        public string Telephone { get; set; }

        [XmlAttribute("fax")]
        public string Fax { get; set; }
    }

    [XmlType("Coordinates", Namespace = "http://educations.com/XmlImport")]
    public class Coordinates
    {
        [XmlAttribute("latitude")]
        public double Latitude { get; set; }

        [XmlAttribute("longitude")]
        public double Longitude { get; set; }
    }
}