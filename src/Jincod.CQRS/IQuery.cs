using System.Threading.Tasks;

namespace Jincod.CQRS
{
    public interface IQuery<in TQueryContext, TResponse>
        where TQueryContext : IQueryContext<TResponse>
    {
        Task<TResponse> ExecuteAsync(TQueryContext queryContext);
    }
}
