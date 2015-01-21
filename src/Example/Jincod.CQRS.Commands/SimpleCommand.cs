namespace Jincod.CQRS.Commands
{
    public class SimpleCommand : ICommand
    {
    }

    public class SimpleCommandHandler : ICommandHandler<SimpleCommand>
    {
        #region ICommandHandler<SimpleCommand> Members

        public void Handle(SimpleCommand command)
        {
            // do something
        }

        #endregion
    }
}