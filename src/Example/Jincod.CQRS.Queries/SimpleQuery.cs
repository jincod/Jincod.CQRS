namespace Jincod.CQRS.Queries
{
    public class SimpleQueryContext : IQueryContext<SimpleEntity>
    {
    }

    public class SimpleQuery : IQuery<SimpleQueryContext, SimpleEntity>
    {
        #region IQuery<SimpleQueryContext,SimpleEntity> Members

        public SimpleEntity Execute(SimpleQueryContext queryContext)
        {
            return new SimpleEntity {Name = "Simpl1"};
        }

        #endregion
    }
}