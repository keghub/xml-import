using System;
using System.Linq;
using AutoFixture;
using AutoFixture.Kernel;
using EMG.XML;
using NUnit.Framework;
using TestHelper;

namespace Tests.Serialization
{
    [TestFixture]
    public class ProviderSerializationTests
    {
        private IFixture fixture;

        [SetUp]
        public void Initialize()
        {
            fixture = new Fixture();

            fixture.Customize<Import>(o => o.With(p => p.Version, 3.0m));

            fixture.Customize<DefaultProviderContentField>(p => p.Without(o => o.Value));
            fixture.Customize<CustomProviderContentField>(p => p.Without(o => o.Value));

            fixture.Customize<DefaultCourseContentField>(p => p.Without(o => o.Value));
            fixture.Customize<CustomCourseContentField>(p => p.Without(o => o.Value));
        }

        [Test]
        public void Minimal_provider_can_be_serialized()
        {
            fixture.Customize<ProviderNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier)
                                                 .With(p => p.Courses, new CourseNode[0])
                                                 .With(p => p.Locations, new LocationNode[0])
                                                 .With(p => p.ContentFields, new ProviderContentField[0]));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Provider_uniqueIdentifier_should_be_unique()
        {
            var sharedUniqueIdentifier = fixture.Create<string>();

            fixture.Customize<ProviderNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier, sharedUniqueIdentifier)
                                                 .With(p => p.Courses, new CourseNode[0])
                                                 .With(p => p.Locations, new LocationNode[0])
                                                 .With(p => p.ContentFields, new ProviderContentField[0]));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void A_Provider_with_Description_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(ProviderContentField), typeof(DefaultProviderContentField)));

            fixture.Customize<ProviderNode>(o => o
                        .With(p => p.Courses, new CourseNode[0])
                        .With(p => p.Locations, new LocationNode[0])
                        .With(p => p.ContentFields, fixture.CreateMany<ProviderContentField>(1).ToArray()));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void A_provider_with_multiple_Description_is_not_valid()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(ProviderContentField), typeof(DefaultProviderContentField)));

            fixture.Customize<DefaultProviderContentField>(o => o.With(p => p.Name, DefaultProviderContentFieldKey.Description).Without(p => p.Value));

            fixture.Customize<ProviderNode>(o => o
                        .With(p => p.Courses, new CourseNode[0])
                        .With(p => p.Locations, new LocationNode[0])
                        .With(p => p.ContentFields, fixture.CreateMany<ProviderContentField>(2).ToArray()));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void A_Provider_with_custom_content_fields_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(ProviderContentField), typeof(CustomProviderContentField)));

            fixture.Customize<ProviderNode>(o => o
                        .With(p => p.Courses, new CourseNode[0])
                        .With(p => p.Locations, new LocationNode[0]));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }
    }
}
