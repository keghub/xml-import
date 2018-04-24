## Education
An `<education />` node contains all the information related to a course or a program.

It supports the following attributes

|Name|Type|Required|Description|
|-|-|-|-|
|uniqueIdentifier|alphanumeric (up to 256)|Yes|The unique identifier for the education|
|name|alphanumeric (up to 128)|Yes|The name of the education|
|educationTypeID|numeric|Yes|The ID of the type of the training method. [See list](education-types.md)|

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

A node can be of two types, `default` and `custom`.

#### Default content fields
The default content fields are fields that contain important information for the visitor.
By using the default content fields, you are making sure that course information is found on our site in the location that users are used to.

Here is the list of default content fields

|Name|Description|
|-|-|
|`description`|A general course description/presentation|
|`qualification`|The course target group, also any prerequisite|
|`degree`|The certification that the participants may receive|
|`continuing`|How to continue the studies after this course (i.e. advanced level etc.)|
|`detailedCost`|Detailed information about pricing and what’s included in the price|
|`technicalPrerequisites`|Technical requirements (i.e. computer, operating system)|

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

### Keywords

### Categories

### Granted certificates

### Link

### Duration

### Default price

### Application

### Credits

### Information Request settings
