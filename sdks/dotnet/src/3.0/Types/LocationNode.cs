using System.ComponentModel;
using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("Location", Namespace = "http://educations.com/XmlImport")]
    public class LocationNode
    {
        [XmlAttribute("uniqueIdentifier")]
        public string UniqueIdentifier { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public bool? HasAccommodation { get; set; }

        [XmlAttribute("hasAccomodation")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasAccommodationField
        {
            get => HasAccommodation.HasValue && HasAccommodationFieldSpecified && HasAccommodation.Value;
            set
            {
                if (value == default(bool))
                {
                    HasAccommodation = null;
                }
                else
                {
                    HasAccommodation = true;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasAccommodationFieldSpecified => HasAccommodation.HasValue;
        
        [XmlIgnore]
        public bool? IsFoodProvided { get; set; }

        [XmlAttribute("isFoodProvided")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFoodProvidedField
        {
            get => IsFoodProvided.HasValue && IsFoodProvidedFieldSpecified && IsFoodProvided.Value;
            set
            {
                if (value == default(bool))
                {
                    IsFoodProvided = null;
                }
                else
                {
                    IsFoodProvided = true;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFoodProvidedFieldSpecified => IsFoodProvided.HasValue;

        [XmlElement("place")]
        public string Place { get; set; }

        [XmlElement("visitingAddress")]
        public AddressNode VisitingAddress { get; set; }

        [XmlElement("mailAddress")]
        public AddressNode MailAddress { get; set; }

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
    public class AddressNode
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

        [XmlAttribute("email")]
        public string Email { get; set; }
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