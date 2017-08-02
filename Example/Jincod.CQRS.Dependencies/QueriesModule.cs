using Autofac;
using Jincod.CQRS.Domain;
using Jincod.CQRS.Queries;

namespace Jincod.CQRS.Dependencies
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SimpleQuery>()
                .As<IQuery<SimpleQueryContext, SimpleEntity>>();
        }
    }
}
