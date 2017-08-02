namespace Jincod.CQRS
{
    public interface ICommandProcessor
    {
        void Process<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
