using System.Threading.Tasks;

namespace Jincod.CQRS
{
    public interface IQueryProcessor
    {
        Task<TResponse> ProcessAsync<TResponse, TContext>(TContext query)
            where TContext : IQueryContext<TResponse>;
    }
}
