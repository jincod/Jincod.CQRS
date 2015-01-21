using System;
using Castle.Windsor;
using Jincod.CQRS.Commands;
using Jincod.CQRS.Queries;

namespace Jincod.CQRS.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new CqrsInstaller(), new CommandsInstaller(), new QueriesInstaller());

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