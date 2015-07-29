using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Jincod.CQRS.Queries
{
    public class QueriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IQuery<SimpleQueryContext, SimpleEntity>>().ImplementedBy<SimpleQuery>());
        }
    }
}