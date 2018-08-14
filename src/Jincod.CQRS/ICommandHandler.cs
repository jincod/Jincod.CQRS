using System.Threading.Tasks;

namespace Jincod.CQRS
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
