# Data format conventions

## Use of HTML in text
Not all the elements accepts text formatted used HTML.
In case an element is allowed to contain HTML text, such text needs to be inserted into a `CDATA` block.
This is needed so that no HTML is erronously interpretated as XML, making the document not valid.

```xml
<text-element>
<![CDATA[<p><b>Lorem ipsum</b> dolor sit amet, consectetuer adipiscing elit.</p>
<p>Suspendisse molestie <b>odio</b> nec nunc. Duis id est.
<br />Cras risus diam, placerat non, facilisis at, lacinia sed, neque.</p>]]>
</text-element>
```

## Decimal values
Decimal values must always be presented with the dot `.` used as decimal separator.

```xml
<element value="12345.678" />
```

## Date and time values
When presenting a value that represents a date, a time or both, the standard [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) must be followed.

### Date
Dates must follow the `YYYY-MM-DD` format, where
* `YYYY` refers to a four-digit year
* `MM` refers to a zero-padded two-digit month of the year, between 01 and 12
* `DD` refers to a zero-padded two-digit day of the month, between 01 and 31

```xml
<element value="2018-04-24" />
```

### Time
Time values must follow the `hh:mm:ss` format, where
* `hh` refers to a zero-padded hour between 00 and 23
* `mm` refers to a zero-padded minute between 00 and 59
* `ss` refers to a zero-padded second between 00 and 59

```xml
<element value="16:12:20" />
```

### Date and time
Values that combine date and time will follow the `YYYY-MM-DDThh:mm:ss` format, where
* `T` is a separator between the date and the time part of the value
* Other tokens follow the guidelines explained earlier

```xml
<element value="2018-04-24T16:12:20" />
```
