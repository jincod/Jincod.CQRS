using System;
using Autofac;
using Jincod.CQRS.Commands;
using Jincod.CQRS.Dependencies;
using Jincod.CQRS.Domain;
using Jincod.CQRS.Queries;

namespace Jincod.CQRS.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CommandsModule>();
            builder.RegisterModule<QueriesModule>();
            builder.RegisterModule<CqrsModule>();

            var container = builder.Build();

            var commandProcessor = container.Resolve<ICommandProcessor>();
            Console.WriteLine("Executing command ...");
            var simpleCommand = new SimpleCommand();
            commandProcessor.Process(simpleCommand);

            Console.WriteLine("Executing query ...");
            var queryProcessor = container.Resolve<IQueryProcessor>();
            var context = new SimpleQueryContext();
            SimpleEntity simpleEntity = queryProcessor.Process<SimpleEntity, SimpleQueryContext>(context);
            Console.WriteLine(simpleEntity.Name);
        }
    }
}