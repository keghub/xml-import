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

### Type of events
The EMG XML 2.0 supports three types of event
* An event of type `LocationEvent` is an event to be held in a specific venue, usually an open-house course.
  - It requires a [location](location.md) to be specified via its unique identifier by the attribute `locationUID`
* An event of type `AreaEvent` is an event that can be held anywhere in a specific place, usually an in-house course.
  - It requires a place to be specified via a symbolic name by the attribute `place`
* An event of type `DistanceEvent` is an event that can be taken without physically attend it, like online.

Because a course can have more than one event, it's possible to have courses that contain events of different types.
