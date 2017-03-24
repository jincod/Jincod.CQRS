using System;
using Autofac;

namespace Jincod.CQRS.Dependencies
{
    public class CqrsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register<QueryProcessor>(ctx => {
                    var container = ctx.Resolve<IComponentContext>();

                    return new QueryProcessor((t1, t2) => container.Resolve(typeof (IQuery<,>).MakeGenericType(t1, t2)));
                })
                .As<IQueryProcessor>();

            builder
                .Register<CommandProcessor>(ctx => {
                    var container = ctx.Resolve<IComponentContext>();

                    return new CommandProcessor((t) => container.Resolve(typeof (ICommandHandler<>).MakeGenericType(t)));
                })
                .As<ICommandProcessor>();
        }
    }
}