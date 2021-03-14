using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCommandHandlers;
using ApiData;
using ApiData.Infastructure;
using ApiData.Repositories;
using Autofac;
using DotNetWebApi.Error;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebApi
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork<EventContext>>().
                As<IUnitOfWork>().
                InstancePerLifetimeScope();

            builder.RegisterType<EventContext>().
                As<DbContext>().
                InstancePerLifetimeScope();

            builder.RegisterType<DbFactory>().
                As<IDbFactory<EventContext>>().
                InstancePerLifetimeScope();

            builder.RegisterType<EventRepository>().
                As<IEventRepository>().
                InstancePerLifetimeScope();
            builder.RegisterType<LocationRepository>().
                As<ILocationRepository>().
                InstancePerLifetimeScope();
            builder.RegisterType<SessionRepository>().
                As<ISessionRepository>().
                InstancePerLifetimeScope();

            builder.RegisterType<ErrorWrappingMiddleware>();
            foreach (var item in typeof(CommandHandler<,>).Assembly.GetTypes())
            {
                if(item.IsAssignableTo<ICommandHandler>() && !item.IsAbstract && !item.IsInterface)
                {
                    builder.RegisterType(item).Named<ICommandHandler>(item.BaseType.GetGenericArguments()[0].FullName);
                }
            }
        }
    }
}
