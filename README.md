# .NET Core shared configuration example
[![Build status](https://ci.appveyor.com/api/projects/status/0m9y8kj9mjujqi14?svg=true)](https://ci.appveyor.com/project/EgorGrishechko/dot-net-core-shared-configuration)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)

## What is the reason?

New configuration system for .NET Core is really awesome.
But in official stylyguides it always uses in the main ASP.NET Core app.
But what if we have other apps in the solution? Or we need to share configuration settings between projects?
Additional info in my [blog-post](http://egorikas.com/asp.net-core-shared-configuration/).

### Entity Framework Core

It's even getting worse, when we want to use `Migrations` from [EF Core](https://docs.microsoft.com/en-us/ef/).
If we don't have parameter less constructor in our `DbContext`, there is a need for implementing `IDbContextFactory`.
And in this case we star to face off a problem with passing `connection string` to our context. 

[Official documentation](https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext) contains an example with hard-coded connection string
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MyProject
{
    public class BloggingContextFactory : IDbContextFactory<BloggingContext>
    {
        public BloggingContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");

            return new BloggingContext(optionsBuilder.Options);
        }
    }
}
```
I don't think, that this is a flexible and right way to do this kind of fabric.

So, with the solution has been written by me, it looks in the next way
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MyProject
{
    public class BloggingContextFactory : IDbContextFactory<BloggingContext>
    {
        public BloggingContext Create()
        {
            var configurationRoot = SettingsProvider.GetConfigurationRoot(new EnvironmentProvider());
            
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            //In my project I put "mainDb" to ConfigurationConstants class
            optionsBuilder.UseSqlite(configurationRoot.GetConnectionString("mainDb"));

            return new BloggingContext(optionsBuilder.Options);
        }
    }
}
```
There is the [article](https://www.benday.com/2017/02/17/ef-core-migrations-without-hard-coding-a-connection-string-using-idbcontextfactory/) with the alternative way for solving this problem. But I don't like it due to low flexibility of configuration settings.

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