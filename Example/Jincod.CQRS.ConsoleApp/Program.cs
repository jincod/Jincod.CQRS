using System;
using System.Threading.Tasks;
using Autofac;
using Jincod.CQRS.Commands;
using Jincod.CQRS.Dependencies;
using Jincod.CQRS.Domain;
using Jincod.CQRS.Queries;

namespace Jincod.CQRS.ConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CommandsModule>();
            builder.RegisterModule<QueriesModule>();
            builder.RegisterModule<CqrsModule>();

            var container = builder.Build();

            var commandProcessor = container.Resolve<ICommandProcessor>();
            Console.WriteLine("Executing command ...");
            var simpleCommand = new SimpleCommand();
            await commandProcessor.ProcessAsync(simpleCommand);
            Console.WriteLine("Simple command");

            Console.WriteLine("Executing query ...");
            var queryProcessor = container.Resolve<IQueryProcessor>();
            var context = new SimpleQueryContext();
            var simpleEntity = await queryProcessor.ProcessAsync<SimpleEntity, SimpleQueryContext>(context);
            Console.WriteLine(simpleEntity.Name);
        }
    }
}
