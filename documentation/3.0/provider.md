## Provider
The `<provider />` node is composed by three nodes:
* `<locations />` that will contain all the provider's [locations](location.md)
* `<courses />` that will contain all the provider's [courses](course.md)
* `<contentFields />` that will contain all the text information regarding the provider

[Here you can find the definition of the `Provider` type](../../schemas/3.0/provider.xsd) and [here you can find some samples](../../samples/3.0/provider-sample.xml).

Both the `<locations />` and the `<courses />` nodes can contain an unlimited amount of items, but all items must have an identifier unique within their scope.

### Content fields
The `<contentFields />` node is used to group all the text information regarding the provider.

A node can be of two types, [`providerDefault`](../../schemas/3.0/provider-text-property.xsd#L13-L19) and [`providerCustom`](../../schemas/3.0/provider-text-property.xsd#L21-L34).

#### Default content fields
The default content fields are fields that contain important information for the visitor.
By using the default content fields, you are making sure that provider information is found on our site in the location that users are used to.

Here is the list of [default content fields](../../schemas/3.0/provider-text-property.xsd#L36-L40)

|Name|Description|
|-|-|
|`description`|A general description/presentation of the provider|

Here is an example of a default field containing the description of the course.
```xml
<field xsi:type="providerDefault" name="description">
<![CDATA[<p><b>Lorem ipsum</b> dolor sit amet, consectetuer adipiscing elit.</p>
<p>Suspendisse molestie <b>odio</b> nec nunc. Duis id est.
<br />Cras risus diam, placerat non, facilisis at, lacinia sed, neque.</p>]]>
</field>
```

#### Custom content fields
The custom content fields are fields that contain additional information about the provider that didn't fit in any of the default fields.

When adding a custom content field, you need to specify the name and whether or not it contains HTML content.

Here is an example of a custom field containing HTML text

```xml
<field xsi:type="providerCustom" name="My custom field" isHtml="true">
<![CDATA[<p><b>Lorem ipsum</b> dolor sit amet, consectetuer adipiscing elit.</p>
<p>Suspendisse molestie <b>odio</b> nec nunc. Duis id est.
<br />Cras risus diam, placerat non, facilisis at, lacinia sed, neque.</p>]]>
</field>
```