namespace Jincod.CQRS
{
    public interface IQueryProcessor
    {
        TResponse Process<TResponse, TContext>(TContext query)
            where TContext : IQueryContext<TResponse>;
    }
}
