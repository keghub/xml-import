using System.Xml.Serialization;

namespace EMG.XML
{
    [XmlType("KnownCurrencies", Namespace = "http://educations.com/XmlImport")]
    public enum Currency
    {
        [XmlEnum] SEK,

        [XmlEnum] EUR,

        [XmlEnum] USD,

        [XmlEnum] GBP,

        [XmlEnum] NOK,

        [XmlEnum] DKK,

        [XmlEnum] CAD,

        [XmlEnum] CHF,

        [XmlEnum] RUB,

        [XmlEnum] SGD,

        [XmlEnum] AUD,

        [XmlEnum] KHR,

        [XmlEnum] PHP,

        [XmlEnum] RMB,

        [XmlEnum] PLN,

        [XmlEnum] HKD,

        [XmlEnum] IDR,
    }
}