using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Jincod.CQRS
{
    public class CqrsInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Command
            var resolveCommandProcessorFunc =
                new Func<Type, object>(t => container.Resolve(typeof (ICommandHandler<>).MakeGenericType(t)));

            container.Register(
                Component.For<ICommandProcessor>()
                    .ImplementedBy<CommandProcessor>()
                    .DependsOn(Dependency.OnValue("func", resolveCommandProcessorFunc)));

            // Query
            var resolveQueryProcessorFunc =
                new Func<Type, Type, object>(
                    (t1, t2) => container.Resolve(typeof (IQuery<,>).MakeGenericType(t1, t2)));

            container.Register(
                Component.For<IQueryProcessor>()
                    .ImplementedBy<QueryProcessor>()
                    .DependsOn(Dependency.OnValue("func", resolveQueryProcessorFunc)));
        }

        #endregion
    }
}