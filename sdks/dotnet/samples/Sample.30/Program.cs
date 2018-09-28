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
                Providers = new[]
                {
                    new ProviderNode
                    {
                        UniqueIdentifier = "provider-3823",
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
                        ContentFields = new ProviderContentField[]
                        {
                            new DefaultProviderContentField
                            {
                                Name = DefaultProviderContentFieldKey.Description,
                                Content = @"This is the description of the provider. It accepts <i>HTML</i>."
                            },
                            new CustomProviderContentField
                            {
                                Name = "About EMG",
                                IsHtml = true,
                                Content = @"Today, EMG is the market leader of education marketing and runs the world's biggest search engines for education and training. The Group works with 4,000 education providers in 40 countries and helps 2 million students find the right course for their needs among the 50,000 programs available each month."
                            }
                        },
                        Courses = new []
                        {
                            new CourseNode
                            {
                                UniqueIdentifier = "course-1",
                                Name = "First course",
                                CourseType = "Course",
                                ContentFields = new CourseContentField[]
                                {
                                    new DefaultCourseContentField
                                    {
                                        Name = DefaultCourseContentFieldKey.Description,
                                        Content = @"This is the description of the course. It accepts <i>HTML</i>."
                                    },
                                    new CustomCourseContentField
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
                                        DeliveryMethod = "Open class",
                                        Language = Language.English
                                    },
                                    new DistanceEvent
                                    {
                                        UniqueIdentifier = "event-2",
                                        DeliveryMethod = "Online",
                                        Language = Language.English
                                    },
                                    new AreaEvent
                                    {
                                        UniqueIdentifier = "event-3",
                                        DeliveryMethod = "In-house",
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
