using System;
using AutoFixture;
using AutoFixture.Kernel;
using EMG.XML;
using NUnit.Framework;
using TestHelper;

namespace Tests.Serialization
{
    [TestFixture]
    public class CourseSerializationTests
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

            fixture.Customize<DefaultCourseContentField>(p => p.Without(o => o.Value));
            fixture.Customize<CustomCourseContentField>(p => p.Without(o => o.Value));
        }

        [Test]
        public void Minimal_course_can_be_serialized()
        {
            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_uniqueIdentifier_must_be_unique()
        {
            var sharedUniqueIdentifier = fixture.Create<string>();

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier, sharedUniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0]));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_default_content_fields_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(CourseContentField), typeof(DefaultCourseContentField)));

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.ContentFields)
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_cant_have_default_content_fields_with_duplicate_key()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(CourseContentField), typeof(DefaultCourseContentField)));

            fixture.Customize<DefaultCourseContentField>(o => o.Without(p => p.Value).With(p => p.Name, DefaultCourseContentFieldKey.Description));

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.ContentFields)
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_custom_content_fields_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(CourseContentField), typeof(CustomCourseContentField)));

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.ContentFields)
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_cant_have_custom_content_fields_with_duplicate_key()
        {
            var fieldName = fixture.Create<string>();

            fixture.Customizations.Add(new TypeRelay(typeof(CourseContentField), typeof(CustomCourseContentField)));

            fixture.Customize<CustomCourseContentField>(o => o.Without(p => p.Value).With(p => p.Name, fieldName));

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.ContentFields)
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            Assert.Throws<AggregateException>(() => XmlSchemas.XmlImport.ValidateDocument(serialized));

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_keywords_can_be_serialized()
        {
            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.Keywords)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_categories_can_be_serialized()
        {
            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.Categories)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_certificates_can_be_serialized()
        {
            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.GrantedCertificates)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_link_can_be_serialized()
        {
            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.Link)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_credits_can_be_serialized()
        {
            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.Credits)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_duration_can_be_serialized()
        {
            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.Duration)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_duration_with_no_unit_can_be_serialized()
        {
            fixture.Customize<CourseDurationSpecificNode>(o => o.Without(p => p.Unit).Without(p => p.UnitAttribute));

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.Duration)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_duration_with_no_text_can_be_serialized()
        {
            fixture.Customize<CourseDurationNode>(o => o.Without(p => p.TextDescription));

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.Duration)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Course_with_information_request_settings_can_be_serialized()
        {
            fixture.Customize<ReceiverItem>(o => o.With(p => p.EmailAddress, "test@testing.com"));

            fixture.Customize<CourseNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.CourseType)
                                               .With(p => p.InformationRequestSettings)
                                               .With(p => p.ContentFields, new CourseContentField[0])
                                               .With(p => p.Events, new EventNode[0])
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }
    }
}