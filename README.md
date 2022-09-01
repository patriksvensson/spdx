# `Spdx`

_[![Spdx NuGet Version](https://img.shields.io/nuget/v/spdx.svg?style=flat&label=NuGet%3A%20Spdx)](https://www.nuget.org/packages/spdx)_

An (unoffical) library for working with [SPDX](https://spdx.dev/) (Software Package Data Exchange).

**License database version:** 3.18

# Features

* Retrieve information about SPDX licenses
* Parse SPDX license expressions
* Create SPDX 2.3 documents

## Examples

See the `Examples` directory for examples of how to use this library.

## Building

We're using [Cake](https://github.com/cake-build/cake) as a 
[dotnet tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools) 
for building. So make sure that you've restored Cake by running 
the following in the repository root:

```
> dotnet tool restore
```

After that, running the build is as easy as writing:

```
> dotnet cake
```

## Copyright

Copyright (c) 2021 Patrik Svensson