# `Spdx`

_[![Spdx NuGet Version](https://img.shields.io/nuget/v/spdx.svg?style=flat&label=NuGet%3A%20Spdx)](https://www.nuget.org/packages/spdx)_

A library that makes it easy to retrieve information about SPDX licenses.

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