using System;
using System.IO;
using System.Xml.Serialization;
using EMG.XML;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var import = CreateImport();

            var serializedContent = SerializeToXml(import);

            Console.Write(serializedContent);
        }

        private static string SerializeToXml(Import import)
        {
            var serializer = new XmlSerializer(typeof(Import));

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, import);

                return writer.ToString();
            }
        }

        private static Import CreateImport()
        {
            var import = new Import
            {
                Institutes = new[]
                {
                    new InstituteNode
                    {
                        Id = 3823,
                        Locations = new []
                        {
                            new LocationNode
                            {
                                UniqueIdentifier = "location-1",
                                Name = "EMG HQ",
                                Place = "Stockholm, Sweden",
                                Coordinates = new Coordinates
                                {
                                    Latitude = 59.335811,
                                    Longitude = 18.098354
                                },
                                VisitingAddress = new AddressNode
                                {
                                    City = "Stockholm",
                                    Country = "Sweden",
                                    Street = "Karlavägen 104",
                                    ZipCode = "115 26"
                                }
                            }
                        },
                        Educations = new []
                        {
                            new EducationNode
                            {
                                UniqueIdentifier = "course-1",
                                Name = "First course",
                                EducationTypeID = 123,
                                ContentFields = new ContentField[]
                                {
                                    new DefaultContentField
                                    {
                                        Name = DefaultTextPropertyKey.Description,
                                        Content = @"This is the description of the course. It accepts <i>HTML</i>."
                                    },
                                    new CustomContentField
                                    {
                                        Name = "Something else",
                                        IsHtml = true,
                                        Content = @"This is a custom text field that can be used to provide additional content. It can accept <i>HTML</i>."
                                    }
                                },
                                Events = new EventNode[]
                                {
                                    new LocationEvent
                                    {
                                        UniqueIdentifier = "event-1",
                                        LocationUniqueIdentifier = "location-1",
                                        EventTypeID = 1,
                                        Language = Language.English
                                    },
                                    new DistanceEvent
                                    {
                                        UniqueIdentifier = "event-2",
                                        EventTypeID = 2,
                                        Language = Language.English
                                    },
                                    new AreaEvent
                                    {
                                        UniqueIdentifier = "event-3",
                                        EventTypeID = 3,
                                        Place = "Stockholm",
                                        Language = Language.English
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return import;
        }
    }
}
