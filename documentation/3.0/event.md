## Event

An _event_ represents an occurrence of a course or program.
An `<event />` node contains all the information related to a specific occurrence, like where the event is held, its price, its start date and time and so on.

[Here you can find the definition of the `Event` type](../../schemas/3.0/event.xsd)

As for [provider](provider.md), [course](course.md) and [location](location.md), an event must have an identifier which is unique within its scope (i.e. its education).

Here is a list of the supported attributes

|Name|Type|Required|Description|
|-|-|-|-|
|`uniqueIdentifier`|alphanumeric (up to 128)|Yes|The unique identifier for the event|
|`deliveryMethod`|alphanumeric (up to 128)|Yes|The method how the training is delivered.|
|`language`|[enumeration](../../schemas/3.0/language.xsd)|No|The instruction language for this event.|
|`link`|[URI](http://www.datypic.com/sc/xsd/t-xsd_anyURI.html)|No|A URL pointing to the page of this event|

In addition, the following nested elements are supported

* [`<price />`](#price) (optional)
* [`<start />`](#event-start) (optional)
* [Additional optional fields](#additional-information)

### Type of events

The EMG XML 3.0 supports three types of event
* An event of type `LocationEvent` is an event to be held in a specific venue, usually an open-house course.
  - It requires a [location](location.md) to be specified via its unique identifier by the attribute `locationUID`
* An event of type `AreaEvent` is an event that can be held anywhere in a specific place, usually an in-house course.
  - It requires a place to be specified via a symbolic name by the attribute `place`
* An event of type `DistanceEvent` is an event that can be taken without physically attend it, like online.

Since a course can have more than one event, it's possible to have courses that contain events of different types.

### Price

The `<price />` element is an instance of the type [`Price`](../../schemas/3.0/event.xsd#L136-L171) and is used to specify the price of the event.

The only required attribute is `price`. It accepts a decimal value representing the cost of the event.

If your event uses a currency that differs from the default one of the site, you can use the `currency` attribute. It accepts any of [these values](../../schemas/3.0/currency.xsd).

You can specify the VAT rate for the course and whether or not the VAT is already included in the amount specified in the `price` attribute.

Additionally, you can specify the discount to be applied on the cost of the course. 
The value of the discount can be supplied either directly or as a percentual rate. In both cases, you can specify a period when the discount is active.

Please note that a `price` node with its price set to `0` will be considered as a free course.

```xml
<!-- This event costs 1250 and uses the default currency --> 
<price price="1250.00" />

<!-- This event costs 1250 EUR --> 
<price price="1250.00" currency="EUR" />

<!-- An event that costs 1250 EUR and has a VAT of 25% already included --> 
<price price="1250.00" currency="EUR" vatIncluded="true" vat="25.00" />

<!-- This event costs 1250 EUR and has a discount of 250 EUR -->
<price price="1250.00" currency="EUR">
    <discount value="250" />
</price>

<!-- This event costs 1250 EUR and has a discount of 10% in December 2018 -->
<price price="1250.00" currency="EUR">
    <discountRate percentage="10" startDate="2018-12-01" endDate="2018-12-31" />
</price>

<!-- A free event -->
<price price="0" />
```

### Event start

The `<start />` element is an instance of the type [`StartInfo`](../../schemas/3.0/event-start-info.xsd) and is used to specify when the event will start and its occurrance, if any.

The schema supports five different type of event starts, each requires different information.

#### Fixed start

An event start of type [`Fixed`](../../schemas/3.0/event-start-info.xsd#L10-L19) is used when an event starts on a specific date.
Additionally, you can specify start time, end date and end time.

```xml
<!-- This events starts on April 26th -->
<start xsi:type="Fixed" startDate="2018-04-26" />

<!-- This events starts on April 26th at 08:30 -->
<start xsi:type="Fixed" startDate="2018-04-26" startTime="08:30:00" />

<!-- This events starts on April 23rd and ends on April 27th -->
<start xsi:type="Fixed" startDate="2018-04-23" endDate="2018-04-27" />

<!-- This events starts on April 26th at 08:30 and ends at 17:30 -->
<start xsi:type="Fixed" startDate="2018-04-26" startTime="08:30:00" endTime="17:30:00" />
```

#### Month start

An event start of type [`Month`](../../schemas/3.0/event-start-info.xsd#L21-L35) is used when an event starts anytime in a month.

The element requires a number to represent the month (from 1 to 12).
Additionally, you can specify an year (in 4 digit format). If not specified, the event is assumed to start every year at the given month.

```xml
<!-- This events starts sometimes in December 2018 -->
<start xsi:type="Month" month="12" year="2018" />

<!-- This events starts sometimes every December -->
<start xsi:type="Month" month="12" />

```

#### Semester start

An event start of type [`Semester`](../../schemas/3.0/event-start-info.xsd#L37-L52) is used when an event starts anytime in a semester.

The schema defines three semesters, `Spring`, `Summer`, and `Fall` without explicitly defining the period of reference.
Additionally, you can specify an year (in 4 digit format). If not specified, the event is assumed to start every year at the given semester.

```xml
<!-- This event starts during the spring of the 2018 -->
<start xsi:type="Semester" semester="Spring" year="2018" />

<!-- This event starts every spring -->
<start xsi:type="Semester" semester="Spring" />
```

#### Always on

An event start of type [`AlwaysOn`](../../schemas/3.0/event-start-info.xsd#L54-L58) is used when an event is always ready to start. It does not require additional information.

```xml
<start xsi:type="AlwaysOn" />
```

#### Text

An event start of type [`Text`](../../schemas/3.0/event-start-info.xsd#L60-L66) is used to present information about the start of an event in a paragraph.

Note that users will not be able to filter events that have their start set to an instance of this type.

```xml
<start xsi:type="Text" description="Lorem ipsum dolor sit amet." />
```

### Additional information

The schema supports additional optional nodes to cover some corner cases.

[`<applicationInfo />`](../../schemas/3.0/event.xsd#L173-L190) is used to enable the deep linking into some application systems. It requires an URL and an application code. Additionally, it supports the possibility to make the link available only during a set period of time.

[`<lastApplicationDate />`](../../schemas/3.0/event.xsd#L27-L34) is used to display information about the last available date to apply to the event. It's content can either be a date or a descriptive text.

The [`<flags />`](../../schemas/3.0/event.xsd#L118-L134) node is used to provide a list of boolean flags. The information must be handled ad-hoc so please use this element only if so instructed by your account manager.

Finally, [`<additionalInfo />`](../../schemas/3.0/event.xsd#L98-L116) is used to provide unstructured information via a list of key/value tuples. The information contained in these tuples must be handled ad-hoc so please use this element only if so instructed by your account manager.
