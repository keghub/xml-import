using System;
using System.Xml;
using System.Xml.Schema;
using NUnit.Framework;
using Tests.EMG30;

// ReSharper disable CheckNamespace

[SetUpFixture]
public class SetUpClass
{
    private static readonly Uri SchemaUri = new Uri(@"https://raw.githubusercontent.com/emgdev/xml-import/master/schemas/3.0/xml-import.xsd", UriKind.Absolute);

    private static XmlSchemaSet GetXmlSchema()
    {
        XmlSchemaSet schemaSet = new XmlSchemaSet { XmlResolver = new XmlUrlResolver() };
        using (XmlTextReader reader = new XmlTextReader(SchemaUri.ToString()))
        {
            var schema = XmlSchema.Read(reader, null);
            schemaSet.Add(schema);
        }

        schemaSet.Compile();

        return schemaSet;
    }

    [OneTimeSetUp]
    public void FirstInitialization()
    {
        XmlSchemas.XmlImport = GetXmlSchema();
    }
}

