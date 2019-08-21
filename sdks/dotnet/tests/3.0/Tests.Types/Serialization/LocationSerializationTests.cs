﻿using System;
using AutoFixture;
using EMG.XML;
using NUnit.Framework;
using TestHelper;

namespace Tests.EMG30.Serialization {
    [TestFixture]
    public class LocationSerializationTests
    {
        private IFixture fixture;

        [SetUp]
        public void Initialize()
        {
            fixture = new Fixture();

            fixture.Customize<Import>(o => o.With(p => p.Version, 3.0m));

            fixture.Customize<ProviderNode>(o => o
                                                 .With(p => p.Courses, new CourseNode[0])
                                                 .With(p => p.ContentFields, new ProviderContentField[0]));

            fixture.Customize<LocationContacts>(o => o.With(p => p.Email, "test@testing.com"));
        }

        [Test]
        public void Minimal_location_can_be_serialized()
        {
            fixture.Customize<LocationNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier)
                                                 .With(p => p.Place)
                                                 .With(p => p.Name));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Location_uniqueIdentifier_must_be_unique()
        {
            var sharedUniqueIdentifier = fixture.Create<string>();

            fixture.Customize<LocationNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier, sharedUniqueIdentifier)
                                                 .With(p => p.Place)
                                                 .With(p => p.Name));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void Full_location_can_be_serialized()
        {
            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Location_with_coordinates_can_be_serialized()
        {
            fixture.Customize<LocationNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier)
                                                 .With(p => p.Coordinates)
                                                 .With(p => p.Place)
                                                 .With(p => p.Name));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Location_with_visiting_address_can_be_serialized()
        {
            fixture.Customize<LocationNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier)
                                                 .With(p => p.VisitingAddress)
                                                 .With(p => p.Place)
                                                 .With(p => p.Name));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Location_with_mailing_address_can_be_serialized()
        {
            fixture.Customize<LocationNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier)
                                                 .With(p => p.MailAddress)
                                                 .With(p => p.Place)
                                                 .With(p => p.Name));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Location_with_residential_information_can_be_serialized()
        {
            fixture.Customize<LocationNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier)
                                                 .With(p => p.ResidentialInformation)
                                                 .With(p => p.Place)
                                                 .With(p => p.Name));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Location_with_description_can_be_serialized()
        {
            fixture.Customize<LocationNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier)
                                                 .With(p => p.Description)
                                                 .With(p => p.Place)
                                                 .With(p => p.Name));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Location_with_contacts_can_be_serialized()
        {
            fixture.Customize<LocationNode>(o => o
                                                 .OmitAutoProperties()
                                                 .With(p => p.UniqueIdentifier)
                                                 .With(p => p.Contacts)
                                                 .With(p => p.Place)
                                                 .With(p => p.Name));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }
    }
}