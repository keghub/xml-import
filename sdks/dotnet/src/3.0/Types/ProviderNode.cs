using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace EMG.XML
{
    [Serializable]
    [XmlType("Provider", Namespace = "http://educations.com/XmlImport")]
    public class ProviderNode
    {
        [XmlArray("locations")]
        [XmlArrayItem("location")]
        public LocationNode[] Locations { get; set; }

        [XmlArray("courses")]
        [XmlArrayItem("course")]
        public CourseNode[] Courses { get; set; }

        [XmlAttribute("uniqueIdentifier")]
        public string UniqueIdentifier { get; set; }

        [XmlArray("contentFields")]
        [XmlArrayItem("field")]
        public ProviderTextProperty[] ContentFields { get; set; }
    }

    [XmlType("ProviderTextProperty", Namespace = "http://educations.com/XmlImport")]
    [XmlInclude(typeof(ProviderDefaultTextProperty))]
    [XmlInclude(typeof(ProviderCustomTextProperty))]
    public abstract class ProviderTextProperty
    {
        [XmlIgnore]
        public string Content { get; set; }

        [XmlText]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

    [XmlType("providerDefault", Namespace = "http://educations.com/XmlImport")]
    public class ProviderDefaultTextProperty : ProviderTextProperty
    {
        [XmlAttribute("name")]
        public ProviderDefaultTextPropertyKey Name { get; set; }
    }

    [XmlType("ProviderDefaultTextPropertyKey", Namespace = "http://educations.com/XmlImport")]
    public enum ProviderDefaultTextPropertyKey
    {
        [XmlEnum("description")] Description
    }

    [XmlType("providerCustom", Namespace = "http://educations.com/XmlImport")]
    public class ProviderCustomTextProperty : ProviderTextProperty
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("isHtml")]
        [DefaultValue(false)]
        public bool IsHtml { get; set; } = false;
    }
}