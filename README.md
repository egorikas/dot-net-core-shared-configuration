# .NET Core shared configuration example
[![Build status](https://ci.appveyor.com/api/projects/status/0m9y8kj9mjujqi14?svg=true)](https://ci.appveyor.com/project/EgorGrishechko/dot-net-core-shared-configuration)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)

## What is the reason?

New configuration system for .NET Core is really awesome.
But in official stylyguides it always uses in the main ASP.NET Core app.
But what if we have other apps in the solution? Or we need to share configuration settings between projects?

So, this is the exapmle, hot I offer to solve this problem.

## Build

Install [.NET Core SDK](https://www.microsoft.com/net/download/core "official site")

Open folder with `Configuration.sln` in the shell.
Then 
```
    dotnet restore
    dotnet build
```
## Tests
Open folder with `Configuraion.Test.csproj` in the shell.
Then
```
    dotnet test
```