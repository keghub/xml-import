using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("KnownLanguages", Namespace = "http://educations.com/XmlImport")]
    public enum Language
    {
        [XmlEnum] Afrikaans,

        [XmlEnum] Arabic,

        [XmlEnum] Balinese,

        [XmlEnum] Basque,

        [XmlEnum] Buginese,

        [XmlEnum] Bulgarian,

        [XmlEnum] Chinese,

        [XmlEnum] Croatian,

        [XmlEnum] Czech,

        [XmlEnum] Danish,

        [XmlEnum] Dutch,

        [XmlEnum] English,

        [XmlEnum] Estonian,

        [XmlEnum] Filipino,

        [XmlEnum] Finnish,

        [XmlEnum] French,

        [XmlEnum] Frisian,

        [XmlEnum] German,

        [XmlEnum] Greek,

        [XmlEnum] Hebrew,

        [XmlEnum] Hindi,

        [XmlEnum] Hungarian,

        [XmlEnum] Indonesian,

        [XmlEnum] Italian,

        [XmlEnum] Japanese,

        [XmlEnum] Javanese,

        [XmlEnum] Korean,

        [XmlEnum] Latin,

        [XmlEnum] Latvian,

        [XmlEnum] Norwegian,

        [XmlEnum] Persian,

        [XmlEnum] Polish,

        [XmlEnum] Portuguese,

        [XmlEnum] Romanian,

        [XmlEnum] Russian,

        [XmlEnum] Sami,

        [XmlEnum] Sanskrit,

        [XmlEnum] Serbian,

        [XmlEnum] Slovakian,

        [XmlEnum] Slovenian,

        [XmlEnum] Somali,

        [XmlEnum] Spanish,

        [XmlEnum] Sundanese,

        [XmlEnum] Swedish,

        [XmlEnum] Tamil,

        [XmlEnum] Thai,

        [XmlEnum] Tibetan,

        [XmlEnum] Urdu
    }
}