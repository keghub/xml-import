﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("Event", Namespace = "http://educations.com/XmlImport")]
    [XmlInclude(typeof(DistanceEvent))]
    [XmlInclude(typeof(AreaEvent))]
    [XmlInclude(typeof(LocationEvent))]
    public abstract class Event
    {
        [XmlAttribute("uniqueIdentifier")] public string UniqueIdentifier { get; set; }

        [XmlAttribute("deliveryMethod")] public string DeliveryMethod { get; set; }

        [XmlAttribute("language")] public Language Language { get; set; }

        [XmlAttribute("link")] public string Link { get; set; }

        [XmlElement("pace")]
        [DefaultValue(100)]
        public decimal Pace { get; set; }

        [XmlElement("price")] public PriceNode Price { get; set; }

        [XmlElement("applicationInfo")] public EventApplicationNode Application { get; set; }

        [XmlArray("additionalInfo")]
        [XmlArrayItem("item")]
        public AdditionalInfoItem[] AdditionalInfo { get; set; }

        [XmlElement("lastApplicationDate")] public LastApplicationDateNode LastApplicationDate { get; set; }

        [XmlElement("start")] public EventStartInfo StartInfo { get; set; }

        [XmlArray("flags")]
        [XmlArrayItem("flag")]
        public Flag[] Flags { get; set; }

    }

    [XmlType("LocationEvent", Namespace = "http://educations.com/XmlImport")]
    public class LocationEvent : Event
    {
        [XmlAttribute("locationUID")] public string LocationUniqueIdentifier { get; set; }
    }

    [XmlType("AreaEvent", Namespace = "http://educations.com/XmlImport")]
    public class AreaEvent : Event
    {
        [XmlAttribute("place")] public string Place { get; set; }
    }

    [XmlType("DistanceEvent", Namespace = "http://educations.com/XmlImport")]
    public class DistanceEvent : Event
    {

    }

    [XmlType("Price", Namespace = "http://educations.com/XmlImport")]
    public class PriceNode
    {
        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlIgnore] public bool? IsVatIncluded { get; set; }

        [XmlAttribute("vatIncluded")]
        public bool IsVatIncludedField
        {
            get => IsVatIncludedFieldSpecified && IsVatIncluded.HasValue && IsVatIncluded.Value;
            set
            {
                if (value == default(bool))
                {
                    IsVatIncluded = null;
                }

                IsVatIncluded = value;
            }
        }

        [XmlIgnore] public bool IsVatIncludedFieldSpecified => IsVatIncluded.HasValue;

        [XmlIgnore] public Currency? Currency { get; set; }

        [XmlAttribute("currency")]
        public Currency CurrencyField
        {
            get => CurrencyFieldSpecified && Currency.HasValue ? Currency.Value : default(Currency);
            set
            {
                if (value == default(Currency))
                {
                    Currency = null;
                }

                Currency = value;
            }
        }

        [XmlIgnore] public bool CurrencyFieldSpecified => Currency.HasValue;

        private DiscountNode _discount;

        [XmlChoiceIdentifier(nameof(DiscountNodeType))]
        [XmlElement("discountRate", typeof(DiscountRateNode))]
        [XmlElement("discount", typeof(DiscountValueNode))]
        public DiscountNode Discount
        {
            get => _discount;
            set
            {
                if (value is DiscountRateNode rate)
                {
                    _discount = rate;
                    DiscountNodeType = DiscountNodeType.Rate;
                }
                else if (value is DiscountValueNode val)
                {
                    _discount = val;
                    DiscountNodeType = DiscountNodeType.Value;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }

        [XmlIgnore] public DiscountNodeType DiscountNodeType;
    }

    [XmlType(IncludeInSchema = false)]
    public abstract class DiscountNode
    {
        [XmlIgnore] public DateTime? StartDate { get; set; }

        [XmlIgnore] public DateTime? EndDate { get; set; }


        [XmlAttribute("startDate", DataType = "date")]
        public DateTime StartDateField
        {
            get => StartDateFieldSpecified && StartDate.HasValue ? StartDate.Value : default(DateTime);
            set
            {
                if (value == default(DateTime))
                {
                    StartDate = null;
                }

                StartDate = value;
            }
        }

        [XmlAttribute("endDate", DataType = "date")]
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

        [XmlIgnore] public bool StartDateFieldSpecified => StartDate.HasValue;

        [XmlIgnore] public bool EndDateFieldSpecified => EndDate.HasValue;

    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class DiscountRateNode : DiscountNode
    {
        [XmlAttribute("percentage")]
        public decimal Percentage { get; set; }
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class DiscountValueNode : DiscountNode
    {
        [XmlAttribute("value")]
        public decimal Value { get; set; }
    }

    [XmlType(IncludeInSchema = false)]
    public enum DiscountNodeType
    {
        [XmlEnum("discountRate")] Rate,
        [XmlEnum("discount")] Value
    }

    [XmlType("EventApplication", Namespace = "http://educations.com/XmlImport")]
    public class EventApplicationNode
    {
        [XmlAttribute("url")] public string Url { get; set; }

        [XmlAttribute("applicationCode")] public string ApplicationCode { get; set; }

        [XmlIgnore] public DateTime? StartDate { get; set; }

        [XmlIgnore] public DateTime? EndDate { get; set; }


        [XmlAttribute("startDate", DataType = "date")]
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

        [XmlIgnore] public bool StartDateFieldSpecified => StartDate.HasValue;

        [XmlIgnore] public bool EndDateFieldSpecified => EndDate.HasValue;

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
    public class Flag
    {
        [XmlAttribute("name")] public string Name { get; set; }

        [XmlIgnore] public DateTime? StartDate { get; set; }

        [XmlIgnore] public DateTime? EndDate { get; set; }


        [XmlAttribute("startDate", DataType = "date")]
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

        [XmlIgnore] public bool StartDateFieldSpecified => StartDate.HasValue;

        [XmlIgnore] public bool EndDateFieldSpecified => EndDate.HasValue;
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public class LastApplicationDateNode
    {
        public LastApplicationDateNode()
        {
        }

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

        [XmlIgnore] public LastApplicationDateNodeType NodeType;
    }

    [XmlType(IncludeInSchema = false)]
    public enum LastApplicationDateNodeType
    {
        [XmlEnum("date")] Date,
        [XmlEnum("text")] Text
    }
}