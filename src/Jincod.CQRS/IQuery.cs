namespace Jincod.CQRS
{
    public interface IQuery<in TQueryContext, out TResponse>
        where TQueryContext : IQueryContext<TResponse>
    {
        TResponse Execute(TQueryContext queryContext);
    }
}