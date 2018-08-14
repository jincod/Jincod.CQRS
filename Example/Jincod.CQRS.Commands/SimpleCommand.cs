using System;
using System.Threading.Tasks;

namespace Jincod.CQRS.Commands
{
    public class SimpleCommand : ICommand
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class SimpleCommandHandler : ICommandHandler<SimpleCommand>
    {
        public Task HandleAsync(SimpleCommand command)
        {
            // do something
            command.Id = DateTime.UtcNow.Ticks.ToString();

            return Task.CompletedTask;
        }
    }
}
