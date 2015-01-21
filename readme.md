Jincod.CQRS
====================

Interfaces for for develop app using CQRS principle

## Examples ([Full example](https://github.com/jincod/Jincod.CQRS/tree/master/src/Example))

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


# Installation

Available on [NuGet](https://www.nuget.org/)

* Install-Package [Jincod.CQRS](https://www.nuget.org/packages/Jincod.CQRS)

# License

MIT license - http://opensource.org/licenses/mit