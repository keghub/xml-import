using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("Event", Namespace = "http://educations.com/XmlImport")]
    [XmlInclude(typeof(DistanceEvent))]
    [XmlInclude(typeof(AreaEvent))]
    [XmlInclude(typeof(LocationEvent))]
    public abstract class EventNode
    {
        [XmlAttribute("uniqueIdentifier")]
        public string UniqueIdentifier { get; set; }

        [XmlAttribute("eventTypeID")]
        public int EventTypeID { get; set; }

        [XmlIgnore]
        public Language? Language { get; set; }

        [XmlAttribute("language")]
        public Language LanguageAttribute
        {
            get => Language.HasValue && LanguageAttributeSpecified ? Language.Value : default(Language);
            set
            {
                if (value == default(Language))
                {
                    Language = null;
                }
                else
                {
                    Language = value;
                }
            }
        }

        [XmlIgnore]
        public bool LanguageAttributeSpecified => Language.HasValue;

        [XmlAttribute("link", DataType = "anyURI")]
        public string Link { get; set; }

        [XmlElement("pace")]
        [DefaultValue(100)]
        [Range(0, 100)]
        public decimal Pace { get; set; } = 100m;

        [XmlElement("price")]
        public PriceNode Price { get; set; }

        [XmlElement("applicationInfo")]
        public EventApplicationNode Application { get; set; }

        [XmlArray("additionalInfo")]
        [XmlArrayItem("item")]
        public AdditionalInfoItem[] AdditionalInfo { get; set; }

        [XmlElement("lastApplicationDate")]
        public LastApplicationDateNode LastApplicationDate { get; set; }

        [XmlElement("start")]
        public EventStartInfoNode StartInfo { get; set; }
    }

    [XmlType("LocationEvent", Namespace = "http://educations.com/XmlImport")]
    public class LocationEvent : EventNode
    {
        [XmlAttribute("locationUID")]
        public string LocationUniqueIdentifier { get; set; }
    }

    [XmlType("AreaEvent", Namespace = "http://educations.com/XmlImport")]
    public class AreaEvent : EventNode
    {
        [XmlAttribute("place")]
        public string Place { get; set; }
    }

    [XmlType("DistanceEvent", Namespace = "http://educations.com/XmlImport")]
    public class DistanceEvent : EventNode { }

    [XmlType("EventApplication", Namespace = "http://educations.com/XmlImport")]
    public class EventApplicationNode
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

        [XmlAttribute("applicationCode")]
        public string ApplicationCode { get; set; }

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

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class AdditionalInfoItem
    {
        [XmlAttribute("key")]
        [StringLength(32)]
        public string Key { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class LastApplicationDateNode
    {
        public LastApplicationDateNode() { }

        public LastApplicationDateNode(DateTime date)
        {
            Item = date;
            NodeType = LastApplicationDateNodeType.Date;
        }

        public LastApplicationDateNode(string text)
        {
            Item = text;
            NodeType = LastApplicationDateNodeType.Text;
        }

        [XmlChoiceIdentifier("NodeType")]
        [XmlElement("date", Type = typeof(DateTime), DataType = "date")]
        [XmlElement("text", Type = typeof(string), DataType = "string")]
        public object Item { get; set; }

        [XmlIgnore] [EditorBrowsable(EditorBrowsableState.Never)]
        public LastApplicationDateNodeType NodeType;
    }

    [XmlType(IncludeInSchema = false)]
    public enum LastApplicationDateNodeType
    {
        [XmlEnum("date")] Date,
        [XmlEnum("text")] Text
    }
}