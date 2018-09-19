# .NET Framework and .NET Core SDK
Here you can find the source code for the SDK available for .NET Framework and .NET Core.

The SDK is composed by different NuGet packages that can be used to generate correct XML documents matching with the supported schemas.

## Versioning
To properly support both EMG XML 2.0 and EMG XML 3.0, the packages use a 4 part versioning scheme following the pattern of `w.x.y.z`.
* *w* - Refers to the version of the XML schema the package is targeting
  - Allowed values: `2`, `3`
* *x* - Major version number, incremented when there are incompatible API changes
  - Allowed values: positive integers (e.g. `1`,`2`,...)
* *y* - Minor version number, incremented when new functionalities are added in a backward-compatible manner
  - Allowed values: non negative integers (e.g. `0`,`1`,`2`,...)
* *z* - Patch version number, incremented when backward-compatible bug fixes are released.
  - Allowed values: non negative integers (e.g. `0`,`1`,`2`,...)

In other terms, the `x.y.z` part of the version follows the [Semantic Versioning 2.0.0](https://semver.org/).

Here are some examples
- `2.1.0.0` is the first stable version of the SDK targeting the EMG XML 2.0 schema
- `3.1.0.0` is the first stable version of the SDK targeting the EMG XML 3.0 schema

### Referencing the SDK
When usign the packages targeting the EMG XML 2.0 schema, it's suggested to lock the package version so that there is no accidental upgrade to the EMG XML 3.0 schema.
This can be achieved by specifying the allowed versions.

```xml
<!-- From 2.0.0.0 to 3.0.0.0 excluded -->
<PackageReference Include="EMG.XML.Types" Version="[2,3)" />

<!-- From 2.1.0.0 to 2.2.0.0 excluded -->
<PackageReference Include="EMG.XML.Types" Version="[2.1,2.2)" />

<!-- From 3.1.0.0 -->
<PackageReference Include="EMG.XML.Types" Version="3.1.0.0" />
```

## Targeted frameworks
Whenever possible, the SDK targets the following frameworks
* .NET Framework 4.0
* .NET Standard 1.3
* .NET Standard 2.0

Certain components might support .NET Framework 4.6 instead of .NET Framework 4.0 to take advantage of certain features.

## License
The SDK is released according to the [MIT license](../../LICENSE).