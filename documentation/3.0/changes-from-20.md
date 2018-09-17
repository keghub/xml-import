## Changes from EMG XML 2.0

Here are some of the major improvements introduced by this version.

### New names for certain types
In an effort to make the schema easier to understand, certain entities have been renamed to better convey their semantic.

|Old name|New name|
|-|-|
|Institute|Provider|
|Education|Course|
|Event type|Delivery Method|

### Internal identifiers have been removed
Unlike the EMG XML 2.0, this version of the format is fully described by its schema. This has been achieved by removing every need of our internal identifiers.

Our system will try to match the identifiers you provide with the equivalent available in our database. If not possible, explicit mapping will be performed on our side.

### Provider-level content fields
By using the new schema, you can now specify content fields that are relevant to the provider itself. As for the courses, you can use either the available default fields or create your custom ones.

### Better support for pricing
In an effort to make the schema easier to understand, the `defaultPrice` node has been removed from the node representing the course. Prices can only be specified on each event.

On the other hand, it is now possible to specify the amount of discount to apply to the cost of an event. The price can be either a rate or of a set amount. Additionally, you can specify the period when the discount is active.

### Monthly starts can now be repeated
You can mark an event to start every year in a given month by not specifying the year.

### Boolean flags on events
You can now mark an event with a list of boolean flags. Please use this functionality only when instructed to do so by your account manager.