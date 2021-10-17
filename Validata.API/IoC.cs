using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Validata.API
{
    public static class IoC
    {
        public static IContainer LetThereBeIoc(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiModules(services);
            var container = builder.Build();
            return container;
        }

        public static ContainerBuilder RegisterApiModules(this ContainerBuilder builder, IServiceCollection services)
        {
            services.AddAutofac();

            builder.RegisterAssemblyModules(typeof(Startup).Assembly);

            return builder;
        }
    }
}
