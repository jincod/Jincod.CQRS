using Autofac;
using Jincod.CQRS.Commands;

namespace Jincod.CQRS.Dependencies
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SimpleCommandHandler>()
                .As<ICommandHandler<SimpleCommand>>();

        }
    }
}