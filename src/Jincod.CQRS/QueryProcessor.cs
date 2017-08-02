using System;

namespace Jincod.CQRS
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly Func<Type, Type, object> _func;

        public QueryProcessor(Func<Type, Type, object> func)
        {
            _func = func;
        }

        public TResponse Process<TResponse, TContext>(TContext query)
            where TContext : IQueryContext<TResponse>
        {
            var q = (IQuery<TContext, TResponse>) _func(typeof (TContext), typeof (TResponse));
            return q.Execute(query);
        }
    }
}
