## Education
An `<education />` node contains all the information related to a course or a program.

It is an instance of the [complex type Education](../../schemas/2.0/education.xsd#L13) and therefore supports the following attributes

|Name|Type|Required|Description|
|-|-|-|-|
|`uniqueIdentifier`|alphanumeric (up to 256)|Yes|The unique identifier for the education|
|`name`|alphanumeric (up to 128)|Yes|The name of the education|
|`educationTypeID`|numeric|Yes|The ID of the type of the training method. [See list](../shared/education-types.md)|

In addition, it supports the following nested elements
* [`<contentFields />`](#content-fields)
* [`<events />`](#events)
* [`<keywords />`](#keywords) (optional)
* [`<categories />`](#categories) (optional)
* [`<grantedCertificates />`](#granted-certificates) (optional)
* [`<link />`](#link) (optional)
* [`<duration />`](#duration) (optional)
* [`<defaultPrice />`](#default-price) (optional)
* [`<application />`](#application) (optional)
* [`<credits />`](#credits) (optional)
* [`<informationRequestSettings />`](#information-request-settings) (optional)

### Content fields
The `<contentFields />` node is used to group all the text information regarding a course.

A node can be of two types, [`default`](../../schemas/2.0/text-property.xsd#L13-L19) and [`custom`](../../schemas/2.0/text-property.xsd#L21-L34).

Please note that from September 30th 2019, findcourses.co.uk and findcourses.com will no longer support custom content fields.

Instead, please use the default content fields listed below.

#### Default content fields
The default content fields are fields that contain important information for the visitor.
By using the default content fields, you are making sure that course information is found on our site in the location that users are used to.

Here is the list of [default content fields](../../schemas/2.0/text-property.xsd#L36-L47)

|Name|Description|
|-|-|
|`description`|A general course description/presentation|
|`qualification`|The course target group, also any prerequisite|
|`degree`|The certification that the participants may receive|
|`continuing`|How to continue the studies after this course (i.e. advanced level etc.)|
|`detailedCost`|Detailed information about pricing and what’s included in the price|
|`technicalPrerequisites`|Technical requirements (i.e. computer, operating system)|
|`platform`|The platform used during the course (_obsolete_)|
|`applicationDeadline`|The deadline to apply to the course (_obsolete_)|

Here is an example of a default field containing the description of the course.
```xml
<field xsi:type="default" name="description">
<![CDATA[<p><b>Lorem ipsum</b> dolor sit amet, consectetuer adipiscing elit.</p>
<p>Suspendisse molestie <b>odio</b> nec nunc. Duis id est.
<br />Cras risus diam, placerat non, facilisis at, lacinia sed, neque.</p>]]>
</field>
```

#### Custom content fields
The custom content fields are fields that contain additional information about the course that didn't fit in any of the default fields.

When adding a custom content field, you need to specify the name and whether or not it contains HTML content.

Here is an example of a custom field containing HTML text

```xml
<field xsi:type="custom" name="My custom field" isHtml="true">
<![CDATA[<p><b>Lorem ipsum</b> dolor sit amet, consectetuer adipiscing elit.</p>
<p>Suspendisse molestie <b>odio</b> nec nunc. Duis id est.
<br />Cras risus diam, placerat non, facilisis at, lacinia sed, neque.</p>]]>
</field>
```

### Events
The [`<events />`](../../schemas/2.0/education.xsd#L23-L37) node contains a list of events. [Here you can find information about the events](event.md).

### Keywords
The [`<keywords />`](../../schemas/2.0/education.xsd#L39-L44) node contains a list of keywords relevant to the course. Each keyword must be unique.

```xml
<keywords>
  <keyword>a keyword</keyword>
  <keyword>another keyword</keyword>
  <keyword>a third keyword</keyword>
<keywords>
```

This field is optional.

### Categories
The [`<categories />`](../../schemas/2.0/education.xsd#L46-L51) node contains a list of training categories associated to the course. Each item is a name that will be mapped to the existing set of categories on the site and can be up to 64 character long.

```xml
<categories>
  <category name="First category" />
  <category name="Second category" />
  <category name="Third category" />
<categories>
```
Please note that categories are a sorted set. The first category is considered more important than the others.

This field is optional.

### Granted certificates
The [`<grantedCertificates />`](../../schemas/2.0/education.xsd#L53-L58) node contains a list of certificates granted by the course. Each item is simply a name that will be mapped to the existing set of certificates on the site.

```xml
<certificates>
  <certificate name="First certificate" />
  <certificate name="Second certificate" />
  <certificate name="Third certificate" />
<certificates>
```

This field is optional.

### Link
The [`<link />`](../../schemas/2.0/education.xsd#L60-L66) node contains the URL to the page of the course on your site. It's contrainted to the default type [anyURI](http://www.datypic.com/sc/xsd/t-xsd_anyURI.html).

```xml
<link>https://www.educationsmediagroup.com/contact</link>
```

This field is optional.

### Duration
The `<duration />` node is an instance of the type [`EducationDuration`](../../schemas/2.0/education.xsd#L97-L124) and contains information about the duration of the course. You can provide both a descriptive text and a computer readable format.

```xml
<duration text="This course lasts 30 days">
  <specific unit="days" value="30" />
</duration>
```

This field is optional.

### Default price

The `<defaultPrice />` node is an instance of the type [`Price`]() and contains information for prices that will be applied for every event that has no price specification. [Additional information can be found here](event.md#price).

This field is optional.

### Application
The `<application />` node is an instance of the type [`Application`](../../schemas/2.0/education.xsd#L158-L168) and contains the link where visitors can apply for the course or program. 

The content of the element must be a valid URI that matches the default type [anyURI](http://www.datypic.com/sc/xsd/t-xsd_anyURI.html). Additionally, you can specify the period for when the link is valid.

```xml
<!-- Application link with both start and end date -->
<application startDate="2018-05-01" endDate="2018-05-31">https://career.educationsmediagroup.com/jobs</application>

<!-- Application link with only the start date -->
<application startDate="2018-05-01">https://career.educationsmediagroup.com/jobs</application>

<!-- Application link with only the end date -->
<application endDate="2018-05-31">https://career.educationsmediagroup.com/jobs</application>

<!-- Application link with no dates -->
<application>https://career.educationsmediagroup.com/jobs</application>
```

This field is optional.

### Credits
The `<credits />` node is a simple element used to express the total amount of credits granted by the program.

### Information Request settings
The `<informationRequestSettings />` node is an instance of the type [`InformationRequest`](../../schemas/2.0/information-request.xsd#L8-L28) and can be used to specify settings related to our lead system (_information request_).

Currently, you can only specify whom we should forward a lead  for the given course. This can be done by providing up to 5 email addresses.

```xml
<informationRequestSettings>
  <emailReceivers>
    <receiver email="test-1@foo.com" />
    <receiver email="test-2@foo.com" />
    <receiver email="test-3@foo.com" />
  </emailReceivers>
</informationRequestSettings>
```
