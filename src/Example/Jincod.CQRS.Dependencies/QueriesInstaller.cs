using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Jincod.CQRS.Domain;
using Jincod.CQRS.Queries;

namespace Jincod.CQRS.Dependencies
{
    public class QueriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IQuery<SimpleQueryContext, SimpleEntity>>().ImplementedBy<SimpleQuery>());
        }
    }
}