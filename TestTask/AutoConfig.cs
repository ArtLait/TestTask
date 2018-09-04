using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using TestTask.Data.Activities;
using TestTask.Data.Context;
using TestTask.Data.Contexts;
using TestTask.Data.Models;
using TestTask.Data.Repositories;

namespace TestTask.ClientApp
{
    public class AutoConfig
    {
        public static IServiceProvider ConfigureContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);
            
            builder.RegisterType<PictureContext>().As<IPictureContext>();
            builder.RegisterType<PictureRepository>().As<IRepository<Picture>>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork<PictureContext, Picture>>();
            builder.RegisterType<MainActivity>().As<IMainActivity>();

            var container = builder.Build();

            var lifetimeScope = new SimpleInjector.Lifestyles.ThreadScopedLifestyle();

            container.BeginLifetimeScope();

            return container.Resolve<IServiceProvider>();
        }
    }
}
