using System.Threading.Tasks;
using Jincod.CQRS.Domain;

namespace Jincod.CQRS.Queries
{
    public class SimpleQueryContext : IQueryContext<SimpleEntity>
    {
    }

    public class SimpleQuery : IQuery<SimpleQueryContext, SimpleEntity>
    {
        public Task<SimpleEntity> ExecuteAsync(SimpleQueryContext queryContext)
        {
            return Task.FromResult(new SimpleEntity { Name = "Simple1" });
        }
    }
}
