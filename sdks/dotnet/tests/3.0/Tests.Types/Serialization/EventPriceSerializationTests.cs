using System;
using AutoFixture;
using AutoFixture.Kernel;
using EMG.XML;
using NUnit.Framework;
using TestHelper;

namespace Tests.Serialization {
    [TestFixture]
    public class EventPriceSerializationTests
    {
        private IFixture fixture;

        [SetUp]
        public void Initialize()
        {
            fixture = new Fixture();

            fixture.Customize<Import>(o => o.With(p => p.Version, 3.0m));

            fixture.Customize<ProviderNode>(o => o
                                                 .With(p => p.Locations, new LocationNode[0])
                                                 .With(p => p.ContentFields, new ProviderContentField[0]));

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.Events)
                                               .With(p => p.ContentFields, new CourseContentField[0])
            );

            fixture.Customizations.Add(new TypeRelay(typeof(EventNode), typeof(DistanceEvent)));

            fixture.Customize<DistanceEvent>(o => o
                                                  .OmitAutoProperties()
                                                  .With(p => p.UniqueIdentifier)
                                                  .With(p => p.DeliveryMethod)
                                                  .With(p => p.Price)
            );

        }

        [Test]
        public void Minimal_event_price_node_can_be_serialized()
        {
            fixture.Customize<PriceNode>(o => o.OmitAutoProperties().With(p => p.Price));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);

        }

        [Test]
        public void Event_price_node_with_currency_can_be_serialized()
        {
            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Currency)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_vat_can_be_serialized()
        {
            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.VAT)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_vatIncluded_can_be_serialized()
        {
            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.IsVatIncluded)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_no_discount_can_be_serialized()
        {
            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.IsVatIncluded)
                                               .With(p => p.VAT)
                                               .With(p => p.Currency)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_rate_discount_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(DiscountNode), typeof(DiscountRateNode)));

            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Discount)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_rate_discount_with_no_dates_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(DiscountNode), typeof(DiscountRateNode)));

            fixture.Customize<DiscountRateNode>(o => o.OmitAutoProperties()
                                                      .With(p => p.Percentage)
            );

            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Discount)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_rate_discount_with_start_date_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(DiscountNode), typeof(DiscountRateNode)));

            fixture.Customize<DiscountRateNode>(o => o.OmitAutoProperties()
                                                      .With(p => p.Percentage)
                                                      .With(p => p.StartDate)
            );

            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Discount)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_rate_discount_with_end_date_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(DiscountNode), typeof(DiscountRateNode)));

            fixture.Customize<DiscountRateNode>(o => o.OmitAutoProperties()
                                                      .With(p => p.Percentage)
                                                      .With(p => p.EndDate)
            );

            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Discount)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_value_discount_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(DiscountNode), typeof(DiscountValueNode)));

            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Discount)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_value_discount_with_no_dates_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(DiscountNode), typeof(DiscountValueNode)));

            fixture.Customize<DiscountValueNode>(o => o.OmitAutoProperties()
                                                      .With(p => p.Value)
            );

            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Discount)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_value_discount_with_start_date_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(DiscountNode), typeof(DiscountValueNode)));

            fixture.Customize<DiscountValueNode>(o => o.OmitAutoProperties()
                                                      .With(p => p.Value)
                                                      .With(p => p.StartDate)
            );

            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Discount)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Event_price_node_with_value_discount_with_end_date_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(DiscountNode), typeof(DiscountValueNode)));

            fixture.Customize<DiscountValueNode>(o => o.OmitAutoProperties()
                                                      .With(p => p.Value)
                                                      .With(p => p.EndDate)
            );

            fixture.Customize<PriceNode>(o => o.OmitAutoProperties()
                                               .With(p => p.Price)
                                               .With(p => p.Discount)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }
    }
}