## Location

A location represents the physical place where an [event](event.md) is held. An example could be the campuses of a university or the venue of a training course.

### Required fields

The minmum information required for a valid `<location />` element is a unique identifier, a name and the name of the city where the location is placed.

```xml
<location uniqueIdentifier="emg-hq" name="EMG HQ">
  <place>Stockholm</place>
</location>
```

The [`Location`](../../schemas/3.0/location.xsd) type supports additional information.

### Availability of accommodation

To specify whether or not your venue offers accommodation, use the `hasAccomodation` attribute.

```xml
<location uniqueIdentifier="venetian" name="The Venetian" hasAccommodation="true">
  <place>Las Vegas</place>
</location>
```

### Availability of food at the locaton

To specify whether or not your venue offers the possibility to consume a meal, use the `isFoodProvided` attribute.

```xml
<location uniqueIdentifier="venetian" name="The Venetian" isFoodProvided="true">
  <place>Las Vegas</place>
</location>
```

### Visiting address

To specify the visiting address of this location, use the `visitingAddress` element, of type [`Address`](../../schemas/3.0/location.xsd#L60-L96).

The only required information is the street address and the country.

```xml
<visitingAddress street="Karlavägen 104" country="Sweden" />
```

Additionally, you can use the `co`, `city`, and `zip` attributes to enrich your address.

```xml
<visitingAddress street="Karlavägen 104" country="Sweden" zip="115 26" city="Stockholm" />
```

### Post address

To specify the post address of this location, use the `mailAddress` element, of type [`Address`](../../schemas/3.0/location.xsd#L60-L96).

Please check the [Visiting Address](#visiting-address) section.

### Coordinates

To specify the coordinates of the location, use the `coordinates` element of type [`Coordinates`](../../schemas/3.0/location.xsd#L98-L101).

It supports two attributes, both required, `latitude` and `longitude`.

Please make sure you specify the coordinates in [decimal degrees](https://en.wikipedia.org/wiki/Decimal_degrees).

### Description and residential information

You can add a textual description of your location by using the `description` element.
You can also add information about the residential panorama of the location by using the `residentialInformation` element.

### Contacts

You can specify telephone and fax number in the [`contacts`](../../schemas/3.0/location.xsd#L22-L39) element.

