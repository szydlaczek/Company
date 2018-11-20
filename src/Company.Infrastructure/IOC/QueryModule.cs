﻿using Autofac;
using CompanySelf.Infrastructure.CommandQuery.Bus;
using System;
using System.Linq;

namespace CompanySelf.Infrastructure.IOC
{
    public class QueryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(x => x.IsAssignableTo<IHandleQuery>())
            .AsImplementedInterfaces();
            builder.Register<Func<Type, IHandleQuery>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(IHandleQuery<>).MakeGenericType(t);
                    return (IHandleQuery)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<QueryBus>()
                .AsImplementedInterfaces();
        }
    }
}