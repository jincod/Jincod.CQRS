# Jincod.CQRS

[![Build status](https://ci.appveyor.com/api/projects/status/mieoljc0aj53765m?svg=true)](https://ci.appveyor.com/project/jincod/jincod-cqrs)
[![NuGet](https://img.shields.io/nuget/v/jincod.cqrs.svg)](https://www.nuget.org/packages/Jincod.CQRS)

Interfaces for develop app using CQRS principle

## Installation

NuGet package [Jincod.CQRS](https://www.nuget.org/packages/Jincod.CQRS)

```PowerShell
PM> Install-Package Jincod.CQRS
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
    public SimpleEntity Execute(SimpleQueryContext queryContext)
    {
        return new SimpleEntity {Name = "Simpl1"};
    }
}
```

QueryProcessor

```csharp
var queryProcessor = container.Resolve<IQueryProcessor>();
var context = new SimpleQueryContext();
SimpleEntity simpleEntity = queryProcessor.Process<SimpleEntity, SimpleQueryContext>(context);
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
    public void Handle(SimpleCommand command)
    {
        // do something
    }
}
```

CommandProcessor

```csharp
var commandProcessor = container.Resolve<ICommandProcessor>();
var simpleCommand = new SimpleCommand();
commandProcessor.Process(simpleCommand);
```

View [Full example](https://github.com/jincod/Jincod.CQRS/tree/master/Example)
