using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
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

            builder.RegisterType<PictureRepository>().As<IRepository<Picture>>();

            builder.RegisterType<PictureContext>().As<IPictureContext>();
            
            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }
    }
}
