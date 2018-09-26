using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("StartInfo", Namespace = "http://educations.com/XmlImport")]
    [XmlInclude(typeof(TextEventStartInfo))]
    [XmlInclude(typeof(AlwaysOpenEventStartInfo))]
    [XmlInclude(typeof(SemesterEventStartInfo))]
    [XmlInclude(typeof(MonthEventStartInfo))]
    [XmlInclude(typeof(FixedEventStartInfo))]
    public abstract class EventStartInfo { }

    [XmlType("Text", Namespace = "http://educations.com/XmlImport")]
    public class TextEventStartInfo : EventStartInfo
    {
        [XmlAttribute("description")]
        public string Description { get; set; }
    }

    [XmlType("AlwaysOpen", Namespace = "http://educations.com/XmlImport")]
    public class AlwaysOpenEventStartInfo : EventStartInfo { }

    [XmlType("Semester", Namespace = "http://educations.com/XmlImport")]
    public class SemesterEventStartInfo : EventStartInfo
    {
        [XmlAttribute("semester")]
        public Semester Semester { get; set; }

        [XmlIgnore]
        public int? Year { get; set; }

        [XmlAttribute("year")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int YearField
        {
            get => YearFieldSpecified && Year.HasValue ? Year.Value : default(int);
            set
            {
                if (value == default(int))
                {
                    Year = null;
                }
                else
                {
                    Year = value;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool YearFieldSpecified => Year.HasValue;
    }

    [XmlType("Month", Namespace = "http://educations.com/XmlImport")]
    public class MonthEventStartInfo : EventStartInfo
    {
        [XmlAttribute("month")]
        public Month Month { get; set; }

        [XmlIgnore]
        public int? Year { get; set; }

        [XmlAttribute("year")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int YearField
        {
            get => YearFieldSpecified && Year.HasValue ? Year.Value : default(int);
            set
            {
                if (value == default(int))
                {
                    Year = null;
                }
                else
                {
                    Year = value;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool YearFieldSpecified => Year.HasValue;
    }

    [XmlType("Fixed", Namespace = "http://educations.com/XmlImport")]
    public class FixedEventStartInfo : EventStartInfo
    {
        [XmlAttribute("startDate", DataType = "date")]
        public DateTime StartDate { get; set; }

        [XmlIgnore]
        public DateTime? EndDate { get; set; }

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
        public bool EndDateFieldSpecified => EndDate.HasValue;

        [XmlIgnore]
        public DateTime? StartTime { get; set; }

        [XmlAttribute("startTime", DataType = "time")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTime StartTimeField
        {
            get => StartTimeFieldSpecified && StartTime.HasValue ? StartTime.Value : default(DateTime);
            set
            {
                if (value == default(DateTime))
                {
                    StartTime = null;
                }
                else
                {
                    StartTime = value;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StartTimeFieldSpecified => StartTime.HasValue;

        [XmlIgnore]
        public DateTime? EndTime { get; set; }

        [XmlAttribute("endTime", DataType = "time")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTime EndTimeField
        {
            get => EndTimeFieldSpecified && EndTime.HasValue ? EndTime.Value : default(DateTime);
            set
            {
                if (value == default(DateTime))
                {
                    EndTime = null;
                }
                else
                {
                    EndTime = value;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EndTimeFieldSpecified => EndTime.HasValue;
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public enum Semester
    {
        [XmlEnum("Spring")] Spring,
        [XmlEnum("Summer")] Summer,
        [XmlEnum("Fall")] Fall
    }

    [XmlType(AnonymousType = true, Namespace = "http://educations.com/XmlImport")]
    public enum Month
    {
        [XmlEnum("1")] January = 1,
        [XmlEnum("2")] February = 2,
        [XmlEnum("3")] March = 3,
        [XmlEnum("4")] April = 4,
        [XmlEnum("5")] May = 5,
        [XmlEnum("6")] June = 6,
        [XmlEnum("7")] July = 7,
        [XmlEnum("8")] August = 8,
        [XmlEnum("9")] September = 9,
        [XmlEnum("10")] October = 10,
        [XmlEnum("11")] November = 11,
        [XmlEnum("12")] December = 12,
    }
}