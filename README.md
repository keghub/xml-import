# Educations Media Group XML schemas
This repository contains the schema and the relevant documentation to create feeds to easily import big amount of data.

## Supported schemas

Currently we support the following schemas out-of-the-box.

### EMG XML 3.0
EMG XML 3.0 is the latest version of our XML schema.

The new format gives our partners the possibility to share more information with us. At the same time, our partners are required a lower degree of knowledge of our internal system. This is achieved by removing any reference to internal IDs that sometimes made EMG XML 2.0 cumbersome to work with.

[Here you can see the complete documentation for EMG XML 3.0](documentation/3.0) ([changes from EMG XML 2.0](documentation/3.0/changes-from-20.md))

[Here you can see the complete schema for EMG XML 3.0](schemas/3.0)

[Here you can see some samples for EMG XML 3.0](samples/3.0)

### EMG XML 2.0
EMG XML 2.0, previously known as Studentum XML 2.0, is the earlier version of our XML schema.

It is currently considered obsolete and new partners should adopt the 3.0 version.

[Here you can see the complete documentation for EMG XML 2.0](documentation/2.0)

[Here you can see the complete schema for EMG XML 2.0](schemas/2.0)

[Here you can see some samples for EMG XML 2.0](samples/2.0)

### AllaStudier XML
This XML schema is used by partners of [AllaStudier](http://allastudier.se/) to share their courses with us.

It is currently considered obsolete and new partners should adopt the EMG XML 3.0 schema.

[Here you can see the complete schema for AllaStudier XML](schemas/AllaStudier)

## SDKs
Besides the schemas and the documentation for each format, this repository contains also the source code of libraries publicly available to help our partners generate XML documents matching our schemas.

Here is a list of supported platforms
- [.NET Framework and .NET Core](./sdks/dotnet)

## Validator
To help our partners validating the XML documents they have produced, we have created an online validator that accepts either a URL or an uploaded file. It currently supports all our supported formats: EMG XML 3.0, EMG XML 2.0 and AllaStudier.

[Here you can find the online validator](https://xml-validator.educationsmediagroup.com/)