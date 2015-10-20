using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Jincod.CQRS.Commands;

namespace Jincod.CQRS.Dependencies
{
    public class CommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICommandHandler<SimpleCommand>>().ImplementedBy<SimpleCommandHandler>());
        }
    }
}