using System.ComponentModel;
using System.Xml.Serialization;

namespace EMG.XML {
    [XmlType("Price", Namespace = "http://educations.com/XmlImport")]
    public class PriceNode
    {
        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlIgnore]
        public bool? IsVatIncluded { get; set; }

        [XmlAttribute("vatIncluded")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsVatIncludedField
        {
            get => IsVatIncludedFieldSpecified && IsVatIncluded.HasValue && IsVatIncluded.Value;
            set
            {
                if (value == default(bool))
                {
                    IsVatIncluded = null;
                }
                else
                {
                    IsVatIncluded = value;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsVatIncludedFieldSpecified => IsVatIncluded.HasValue;

        [XmlIgnore]
        public Currency? Currency { get; set; }

        [XmlAttribute("currency")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Currency CurrencyField
        {
            get => CurrencyFieldSpecified && Currency.HasValue ? Currency.Value : default(Currency);
            set
            {
                if (value == default(Currency))
                {
                    Currency = null;
                }
                else
                {
                    Currency = value;
                }
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CurrencyFieldSpecified => Currency.HasValue;
    }
}