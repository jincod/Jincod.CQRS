using System.Threading.Tasks;

namespace Jincod.CQRS
{
    public interface ICommandProcessor
    {
        Task ProcessAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
