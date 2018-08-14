# Jincod.CQRS

[![Build status](https://ci.appveyor.com/api/projects/status/mieoljc0aj53765m?svg=true)](https://ci.appveyor.com/project/jincod/jincod-cqrs)
[![NuGet](https://img.shields.io/nuget/v/jincod.cqrs.svg)](https://www.nuget.org/packages/Jincod.CQRS)

Interfaces for develop app using CQRS principle

## Installation

NuGet package [Jincod.CQRS](https://www.nuget.org/packages/Jincod.CQRS)

```PowerShell
Install-Package Jincod.CQRS
```
or 

```bash
dotnet add package Jincod.CQRS
```

## Usage

### Query

QueryContext

```csharp
public class SimpleQueryContext : IQueryContext<SimpleEntity>
{
}
```

Query

```csharp
public class SimpleQuery : IQuery<SimpleQueryContext, SimpleEntity>
{
    public Task<SimpleEntity> ExecuteAsync(SimpleQueryContext queryContext)
    {
        return Task.FromResult(new SimpleEntity { Name = "Simple1" });
    }
}
```

QueryProcessor

```csharp
var queryProcessor = container.Resolve<IQueryProcessor>();
var context = new SimpleQueryContext();
var simpleEntity = await queryProcessor.ProcessAsync<SimpleEntity, SimpleQueryContext>(context);
```

### Commands

Command

```csharp
public class SimpleCommand : ICommand
{
}
```

CommandHandler

```csharp
public class SimpleCommandHandler : ICommandHandler<SimpleCommand>
{
    public Task HandleAsync(SimpleCommand command)
    {
        // do something
        return Task.CompletedTask;
    }
}
```

CommandProcessor

```csharp
var commandProcessor = container.Resolve<ICommandProcessor>();
var simpleCommand = new SimpleCommand();
await commandProcessor.ProcessAsync(simpleCommand);
```

View [Full example](https://github.com/jincod/Jincod.CQRS/tree/master/Example)
