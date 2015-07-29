using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Jincod.CQRS.Commands
{
    public class CommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICommandHandler<SimpleCommand>>().ImplementedBy<SimpleCommandHandler>());
        }
    }
}