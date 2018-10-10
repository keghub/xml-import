using System;
using AutoFixture;
using AutoFixture.Kernel;
using EMG.XML;
using NUnit.Framework;
using TestHelper;

namespace Tests.EMG20.Serialization
{
    [TestFixture]
    public class EducationSerializationTests
    {
        private IFixture fixture;

        [SetUp]
        public void Initialize()
        {
            fixture = new Fixture();

            fixture.Customize<Import>(o => o.With(p => p.Version, 2.0m));

            fixture.Customize<InstituteNode>(o => o
                                                 .With(p => p.Locations, new LocationNode[0]));

            fixture.Customize<DefaultContentField>(p => p.Without(o => o.Value));
            fixture.Customize<CustomContentField>(p => p.Without(o => o.Value));
        }

        [Test]
        public void Minimal_Education_can_be_serialized()
        {
            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_uniqueIdentifier_must_be_unique()
        {
            var sharedUniqueIdentifier = fixture.Create<string>();

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier, sharedUniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0]));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_default_content_fields_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(ContentField), typeof(DefaultContentField)));

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.ContentFields)
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_cant_have_default_content_fields_with_duplicate_key()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(ContentField), typeof(DefaultContentField)));

            fixture.Customize<DefaultContentField>(o => o.Without(p => p.Value).With(p => p.Name, DefaultTextPropertyKey.Description));

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.ContentFields)
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_custom_content_fields_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(ContentField), typeof(CustomContentField)));

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.ContentFields)
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_cant_have_custom_content_fields_with_duplicate_key()
        {
            var fieldName = fixture.Create<string>();

            fixture.Customizations.Add(new TypeRelay(typeof(ContentField), typeof(CustomContentField)));

            fixture.Customize<CustomContentField>(o => o.Without(p => p.Value).With(p => p.Name, fieldName));

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.ContentFields)
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_keywords_can_be_serialized()
        {
            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Keywords)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_categories_can_be_serialized()
        {
            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Categories)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_certificates_can_be_serialized()
        {
            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.GrantedCertificates)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_link_can_be_serialized()
        {
            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Link)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_credits_can_be_serialized()
        {
            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Credits)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_duration_can_be_serialized()
        {
            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Duration)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_duration_with_no_unit_can_be_serialized()
        {
            fixture.Customize<EducationDurationSpecificNode>(o => o.Without(p => p.Unit).Without(p => p.UnitAttribute));

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Duration)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_duration_with_no_text_can_be_serialized()
        {
            fixture.Customize<EducationDurationNode>(o => o.Without(p => p.TextDescription));

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Duration)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_information_request_settings_can_be_serialized()
        {
            fixture.Customize<ReceiverItem>(o => o.With(p => p.EmailAddress, "test@testing.com"));

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.InformationRequestSettings)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_application_data_with_no_dates_can_be_serialized()
        {
            fixture.Customize<EducationApplicationNode>(o => o
                                                          .OmitAutoProperties()
                                                          .With(p => p.Url)
            );

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Application)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_application_data_with_start_date_can_be_serialized()
        {
            fixture.Customize<EducationApplicationNode>(o => o
                                                          .OmitAutoProperties()
                                                          .With(p => p.Url)
                                                          .With(p => p.StartDate)
            );

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Application)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Education_with_application_data_with_end_date_can_be_serialized()
        {
            fixture.Customize<EducationApplicationNode>(o => o
                                                          .OmitAutoProperties()
                                                          .With(p => p.Url)
                                                          .With(p => p.StartDate)
            );

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Application)
                                               .With(p => p.ContentFields, new ContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }
    }
}