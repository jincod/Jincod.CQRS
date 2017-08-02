namespace Jincod.CQRS.Commands
{
    public class SimpleCommand : ICommand
    {
    }

    public class SimpleCommandHandler : ICommandHandler<SimpleCommand>
    {
        public void Handle(SimpleCommand command)
        {
            // do something
        }
    }
}
