## Event

An _event_ represents an occurrence of a course or program.
An `<event />` node contains all the information related to a specific occurrence, like where the event is held, its price, its start date and time and so on.

[Here you can find the definition of the `Event` type](../../schemas/2.0/event.xsd)

As for [institute](institute.md), [education](education.md) and [location](location.md), an event must have an identifier which is unique within its scope (i.e. its education).

Here is a list of the supported attributes

|Name|Type|Required|Description|
|-|-|-|-|
|`uniqueIdentifier`|alphanumeric (up to 128)|Yes|The unique identifier for the event|
|`eventTypeID`|numeric|Yes|The ID of the type of the training method. [See list](event-types.md)|
|`language`|[enumeration](../../schemas/2.0/language.xsd)|No|The instruction language for this event.|
|`link`|[URI](http://www.datypic.com/sc/xsd/t-xsd_anyURI.html)|No|A URL pointing to the page of this event|

In addition, the following nested elements are supported

* [`<price />`](#price) (optional)
* [`<start />`](#start) (optional)
* [`<additionalInfo />`](#additional-information) (optional)
* [`<applicationInfo />`](#application-information) (optional)
* [`<lastApplicationDate />`](#last-application-date) (optional)

### Type of events

The EMG XML 2.0 supports three types of event
* An event of type `LocationEvent` is an event to be held in a specific venue, usually an open-house course.
  - It requires a [location](location.md) to be specified via its unique identifier by the attribute `locationUID`
* An event of type `AreaEvent` is an event that can be held anywhere in a specific place, usually an in-house course.
  - It requires a place to be specified via a symbolic name by the attribute `place`
* An event of type `DistanceEvent` is an event that can be taken without physically attend it, like online.

Since a course can have more than one event, it's possible to have courses that contain events of different types.

### Price

The `<price />` element is an instance of the type [`Price`](../../schemas/2.0/event.xsd#L111-L123) and is used to specify the price of the event.

The only required attribute is `price`. It accepts a decimal value representing the cost of the event.

If your event uses a currency that differs from the default one of the site, you can use the `currency` attribute. It accepts any of [these values](../../schemas/2.0/currency.xsd).

Additionally, you can specify the VAT rate for the course and whether or not the VAT is already included in the amount specified in the `price` attribute.

Please note that a `price` node with its price set to `0` will be considered as a free course.

```xml
<!-- This event costs 1250 and uses the default currency --> 
<price price="1250.00" />

<!-- This event costs 1250 EUR --> 
<price price="1250.00" currency="EUR" />

<!-- An event that costs 1250 EUR and has a VAT of 25% already included --> 
<price price="1250.00" currency="EUR" vatIncluded="true" vat="25.00" />

<!-- A free event -->
<price price="0" />
```
