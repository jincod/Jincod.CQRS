using System;

namespace Jincod.CQRS
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Func<Type, object> _func;

        public CommandProcessor(Func<Type, object> func)
        {
            _func = func;
        }

        public void Process<TCommand>(TCommand command) where TCommand : ICommand
        {
            var q = (ICommandHandler<TCommand>) _func(typeof (TCommand));
            q.Handle(command);
        }
    }
}