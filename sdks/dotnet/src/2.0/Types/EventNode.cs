using System;
using System.ComponentModel;
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

        [XmlAttribute("deliveryMethod")]
        public string DeliveryMethod { get; set; }

        [XmlAttribute("language")]
        public Language Language { get; set; }

        [XmlAttribute("link")]
        public string Link { get; set; }

        [XmlElement("pace")]
        [DefaultValue(100)]
        public decimal Pace { get; set; }

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

        [XmlArray("flags")]
        [XmlArrayItem("flag")]
        public FlagNode[] Flags { get; set; }
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
        [XmlAttribute("url")]
        public string Url { get; set; }

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
        public string Key { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class FlagNode
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

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