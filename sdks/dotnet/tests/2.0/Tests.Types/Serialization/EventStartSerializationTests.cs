using System;
using AutoFixture;
using AutoFixture.Kernel;
using EMG.XML;
using NUnit.Framework;
using TestHelper;

namespace Tests.EMG20.Serialization
{
    [TestFixture]
    public class EventStartSerializationTests
    {
        private IFixture fixture;

        [SetUp]
        public void Initialize()
        {
            fixture = new Fixture();

            fixture.Customize<Import>(o => o.With(p => p.Version, 2.0m));

            fixture.Customize<InstituteNode>(o => o.With(p => p.Locations, new LocationNode[0]));

            fixture.Customize<EducationNode>(o => o
                                               .OmitAutoProperties()
                                               .With(p => p.UniqueIdentifier)
                                               .With(p => p.Name)
                                               .With(p => p.EducationTypeID)
                                               .With(p => p.Events)
                                               .With(p => p.ContentFields, new ContentField[0])
            );

            fixture.Customizations.Add(new TypeRelay(typeof(EventNode), typeof(DistanceEvent)));

            fixture.Customize<DistanceEvent>(o => o
                                                  .OmitAutoProperties()
                                                  .With(p => p.UniqueIdentifier)
                                                  .With(p => p.EventTypeID)
                                                  .With(p => p.StartInfo)
            );

        }

        [Test]
        public void AlwaysOn_start_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(AlwaysOpenEventStartInfoNode)));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Text_start_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(TextEventStartInfoNode)));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Month_start_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(MonthEventStartInfoNode)));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Month_start_with_no_year_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(MonthEventStartInfoNode)));

            fixture.Customize<MonthEventStartInfoNode>(o => o.OmitAutoProperties().With(p => p.Month));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Semester_start_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(SemesterEventStartInfoNode)));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Semester_start_with_no_year_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(SemesterEventStartInfoNode)));

            fixture.Customize<SemesterEventStartInfoNode>(o => o.OmitAutoProperties().With(p => p.Semester));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Fixed_start_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(FixedEventStartInfoNode)));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Fixed_start_with_no_extra_info_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(FixedEventStartInfoNode)));

            fixture.Customize<FixedEventStartInfoNode>(o => o.OmitAutoProperties().With(p => p.StartDate));

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Fixed_start_with_end_date_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(FixedEventStartInfoNode)));

            fixture.Customize<FixedEventStartInfoNode>(o => o.OmitAutoProperties()
                                                             .With(p => p.StartDate)
                                                             .With(p => p.EndDate)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Fixed_start_with_start_time_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(FixedEventStartInfoNode)));

            fixture.Customize<FixedEventStartInfoNode>(o => o.OmitAutoProperties()
                                                             .With(p => p.StartDate)
                                                             .With(p => p.StartTime)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }

        [Test]
        public void Fixed_start_with_end_time_can_be_serialized()
        {
            fixture.Customizations.Add(new TypeRelay(typeof(EventStartInfoNode), typeof(FixedEventStartInfoNode)));

            fixture.Customize<FixedEventStartInfoNode>(o => o.OmitAutoProperties()
                                                             .With(p => p.StartDate)
                                                             .With(p => p.EndTime)
            );

            var import = fixture.Create<Import>();

            var serialized = import.ToXml();

            XmlSchemas.XmlImport.ValidateDocument(serialized);

            Console.Write(serialized);
        }
    }
}