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
    public class InstituteSerializationTests
    {
        private IFixture fixture;

        [SetUp]
        public void Initialize()
        {
            fixture = new Fixture();

            fixture.Customize<Import>(o => o.With(p => p.Version, 2.0m));

            fixture.Customize<ContentField>(p => p.Without(o => o.Value));
            fixture.Customize<CustomContentField>(p => p.Without(o => o.Value));
        }

        [Test]
        public void Minimal_provider_can_be_serialized()
        {
            fixture.Customize<InstituteNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.Id)
                                                 .With(p => p.Educations, new EducationNode[0])
                                                 .With(p => p.Locations, new LocationNode[0]));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Provider_uniqueIdentifier_should_be_unique()
        {
            var sharedId = fixture.Create<int>();

            fixture.Customize<InstituteNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.Id, sharedId)
                                                 .With(p => p.Educations, new EducationNode[0])
                                                 .With(p => p.Locations, new LocationNode[0]));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }
    }
}
