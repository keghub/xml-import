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
        public ProviderContentField[] ContentFields { get; set; }
    }

    [XmlType("ProviderTextProperty", Namespace = "http://educations.com/XmlImport")]
    [XmlInclude(typeof(DefaultProviderContentField))]
    [XmlInclude(typeof(CustomProviderContentField))]
    public abstract class ProviderContentField
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
    public class DefaultProviderContentField : ProviderContentField
    {
        [XmlAttribute("name")]
        public DefaultProviderContentFieldKey Name { get; set; }
    }

    [XmlType("ProviderDefaultTextPropertyKey", Namespace = "http://educations.com/XmlImport")]
    public enum DefaultProviderContentFieldKey
    {
        [XmlEnum("description")] Description
    }

    [XmlType("providerCustom", Namespace = "http://educations.com/XmlImport")]
    public class CustomProviderContentField : ProviderContentField
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("isHtml")]
        [DefaultValue(false)]
        public bool IsHtml { get; set; } = false;
    }
}