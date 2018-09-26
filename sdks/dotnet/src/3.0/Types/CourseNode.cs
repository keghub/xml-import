using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("Course", Namespace = "http://educations.com/XmlImport")]
    public class CourseNode
    {
        [XmlAttribute("uniqueIdentifier")]
        public string UniqueIdentifier { get; set; }

        [XmlArray("contentFields")]
        [XmlArrayItem("field")]
        public CourseTextProperty[] ContentFields { get; set; }

        [XmlArray("events")]
        [XmlArrayItem("event")]
        public EventNode[] Events { get; set; }
    }

    [XmlType("CourseTextProperty", Namespace = "http://educations.com/XmlImport")]
    [XmlInclude(typeof(CourseDefaultTextProperty))]
    [XmlInclude(typeof(CourseCustomTextProperty))]
    public abstract class CourseTextProperty
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
    public class CourseDefaultTextProperty : CourseTextProperty
    {
        [XmlAttribute("name")]
        public CourseDefaultTextPropertyKey Name { get; set; }
    }

    [XmlType("CourseDefaultTextPropertyKey", Namespace = "http://educations.com/XmlImport")]
    public enum CourseDefaultTextPropertyKey
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
    public class CourseCustomTextProperty : CourseTextProperty
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("isHtml")]
        [DefaultValue(false)]
        public bool IsHtml { get; set; } = false;
    }
}