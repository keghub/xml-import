using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("Education", Namespace = "http://educations.com/XmlImport")]
    public class EducationNode
    {
        [XmlAttribute("uniqueIdentifier")]
        public string UniqueIdentifier { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("educationTypeID")]
        public int EducationTypeID { get; set; }

        [XmlArray("contentFields")]
        [XmlArrayItem("field")]
        public ContentField[] ContentFields { get; set; }

        [XmlArray("events")]
        [XmlArrayItem("event")]
        public EventNode[] Events { get; set; }

        [XmlArray("keywords")]
        [XmlArrayItem("keyword")]
        public string[] Keywords { get; set; }

        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public NamedNode[] Categories { get; set; }

        [XmlArray("grantedCertificates")]
        [XmlArrayItem("certificate")]
        public NamedNode[] GrantedCertificates { get; set; }

        [XmlElement("link", DataType = "anyURI")]
        public string Link { get; set; }

        [XmlIgnore]
        public decimal? Credits { get; set; }

        [XmlElement("credits")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public decimal CreditsField
        {
            get => Credits.HasValue && CreditsFieldSpecified ? Credits.Value : default(decimal);
            set
            {
                if (value == default(int))
                {
                    Credits = null;
                }
                else
                {
                    Credits = value;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CreditsFieldSpecified => Credits.HasValue;

        [XmlElement("application")]
        public EducationApplicationNode Application { get; set; }

        [XmlElement("informationRequestSettings")]
        public InformationRequestNode InformationRequestSettings { get; set; }

        [XmlElement("duration")]
        public EducationDurationNode Duration { get; set; }

        [XmlElement("defaultPrice")]
        public PriceNode DefaultPrice { get; set; }

    }

    [XmlType("TextProperty", Namespace = "http://educations.com/XmlImport")]
    [XmlInclude(typeof(DefaultContentField))]
    [XmlInclude(typeof(CustomContentField))]
    public abstract class ContentField
    {
        [XmlIgnore]
        public string Content { get; set; }

        [XmlText]
        public XmlNode[] Value
        {
            get => new XmlNode[] { new XmlDocument().CreateCDataSection(Content) };
            set
            {
                if (value == null)
                {
                    Content = null;
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException($"Invalid array length {value.Length}");
                }

                Content = value[0].Value;
            }
        }
    }

    [XmlType("default", Namespace = "http://educations.com/XmlImport")]
    public class DefaultContentField : ContentField
    {
        [XmlAttribute("name")]
        public DefaultTextPropertyKey Name { get; set; }
    }

    [XmlType("DefaultTextPropertyKey", Namespace = "http://educations.com/XmlImport")]
    public enum DefaultTextPropertyKey
    {
        [XmlEnum("description")] Description,

        [XmlEnum("qualification")] Qualification,

        [XmlEnum("platform")] Platform,

        [XmlEnum("degree")] Degree,

        [XmlEnum("continuing")] Continuing,

        [XmlEnum("detailedCost")] DetailedCost,

        [XmlEnum("technicalPrerequisites")] TechnicalPrerequisites,

        [XmlEnum("applicationDeadline")] ApplicationDeadline,
    }

    [XmlType("custom", Namespace = "http://educations.com/XmlImport")]
    public class CustomContentField : ContentField
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("isHtml")]
        [DefaultValue(false)]
        public bool IsHtml { get; set; } = false;
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class NamedNode
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        public static implicit operator NamedNode(string name) => new NamedNode { Name = name };
    }

    [XmlType("Application", Namespace = "http://educations.com/XmlImport")]
    public class EducationApplicationNode
    {
        [XmlIgnore]
        public Uri Url { get; set; }

        [XmlAttribute("url", DataType = "anyURI")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UrlField
        {
            get => Url.ToString();
            set => Url = value == null ? null : new Uri(value);
        }

        [XmlIgnore]
        public DateTime? StartDate { get; set; }

        [XmlIgnore]
        public DateTime? EndDate { get; set; }

        [XmlAttribute("startDate", DataType = "date")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTime StartDateField
        {
            get => StartDateFieldSpecified && StartDate.HasValue ? StartDate.Value : default(DateTime);
            set
            {
                if (value == default(DateTime))
                {
                    StartDate = null;
                }
                else
                {
                    StartDate = value;
                }
            }
        }

        [XmlAttribute("endDate", DataType = "date")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTime EndDateField
        {
            get => EndDateFieldSpecified && EndDate.HasValue ? EndDate.Value : default(DateTime);
            set
            {
                if (value == default(DateTime))
                {
                    EndDate = null;
                }
                else
                {
                    EndDate = value;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StartDateFieldSpecified => StartDate.HasValue;

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EndDateFieldSpecified => EndDate.HasValue;
    }

    [XmlType("InformationRequest", Namespace = "http://educations.com/XmlImport")]
    public class InformationRequestNode
    {
        private ReceiverItem[] _receivers;

        [XmlArray("emailReceivers")]
        [XmlArrayItem("receiver")]
        public ReceiverItem[] Receivers
        {
            get => _receivers;
            set
            {
                if (value != null && value.Length > 5)
                {
                    throw new ArgumentException("You can specify up to 5 receivers", nameof(value));
                }

                _receivers = value;
            }
        }
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class ReceiverItem
    {
        [XmlAttribute("email")]
        public string EmailAddress { get; set; }
    }

    [XmlType("EducationDuration", Namespace = "http://educations.com/XmlImport")]
    public class EducationDurationNode
    {
        [XmlAttribute("text")]
        public string TextDescription { get; set; }

        [XmlElement("specific")]
        public EducationDurationSpecificNode Specific { get; set; }
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class EducationDurationSpecificNode
    {
        [XmlAttribute("value")]
        public decimal Value { get; set; }

        [XmlIgnore]
        public EducationDurationUnit? Unit { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UnitAttributeSpecified => Unit.HasValue;

        [XmlAttribute("unit")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EducationDurationUnit UnitAttribute
        {
            get => Unit.HasValue && UnitAttributeSpecified ? Unit.Value : default(EducationDurationUnit);
            set
            {
                if (value == default(EducationDurationUnit))
                {
                    Unit = null;
                }
                else
                {
                    Unit = value;
                }

            }
        }
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public enum EducationDurationUnit
    {
        [XmlEnum("hours")] Hours = 1,

        [XmlEnum("days")] Days,

        [XmlEnum("weeks")] Weeks,

        [XmlEnum("months")] Months,

        [XmlEnum("years")] Years,

        [XmlEnum("semesters")] Semesters
    }

}