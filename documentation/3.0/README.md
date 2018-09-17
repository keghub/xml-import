# EMG XML 3.0
EMG XML 3.0 is a XML schema designed to easily import structured data representing a training provider and its courses or programs.

## Differences with EMG XML 2.0
The changes we introduced in this version of the schema are deep enough to require a new major version.

Whilst we support both EMG XML 2.0 and 3.0, the two formats are not interchangeable. Marking a 2.0-document with a 3.0 tag or viceversa will cause the validation process to fail.

[Here are the changes introduced with EMG XML 3.0](changes-from-20.md).

## Publishing the feed
The file containing the information to be imported (from now on: the _feed_) can be either static or dynamically generated on request. Please make sure that the content is delivered within a reasonable amount of time from the request.

Our system supports the retrieval of the feed via HTTP, HTTPS and FTP.
Basic authentication methods are also supported out-of-the-box. [Here you can find more information about the supported authentication methods](../shared/authentication.md).

Make sure that the feed correctly validates against the [EMG XML 3.0 schema](../../schemas/3.0).

Regularly, we will download the feed and process it to determine which courses have to be published, unpublished and updated.

## Data format conventions
To be able to import data from different partners, we require our partners to follow a certain set of conventions in regard on how to print data of certain type. [Here you can find a detailed list of conventions to be followed when creating your feed](../shared/data-format-conventions.md).

## Overview of the schema
The schema uses four main entities
* A [`provider`](provider.md) represents a university or a training provider
* A [`course`](course.md) represents a course or a program
* A [`location`](location.md) represents a venue where a course can be held
* An [`event`](event.md) represents an occurrence of a course or program

Each of these entities have an identifier that must be unique within their scope.
We use the identifier to determine whether a certain entity is new, needs to be updated or has been removed.

```xml
<?xml version="1.0" encoding="utf-8"?>
<import version="3.0" xmlns="http://educations.com/XmlImport" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <provider uniqueIdentifier="abcde-12345">
    <courses>
      <course />
      ...
    </course>
    <locations>
      <location />
      ...
    </locations>
  </provider>
</import>
```

The schema supports more than one provider. Each provider will need to have an identifier unique within its scope.