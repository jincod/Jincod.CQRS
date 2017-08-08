using System;

namespace Jincod.CQRS.Commands
{
    public class SimpleCommand : ICommand
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class SimpleCommandHandler : ICommandHandler<SimpleCommand>
    {
        public void Handle(SimpleCommand command)
        {
            // do something
            command.Id = DateTime.UtcNow.Ticks.ToString();
        }
    }
}
