using Jincod.CQRS.Domain;

namespace Jincod.CQRS.Queries
{
    public class SimpleQueryContext : IQueryContext<SimpleEntity>
    {
    }

    public class SimpleQuery : IQuery<SimpleQueryContext, SimpleEntity>
    {
        public SimpleEntity Execute(SimpleQueryContext queryContext)
        {
            return new SimpleEntity {Name = "Simple1"};
        }
    }
}
