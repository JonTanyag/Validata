using System;
using Autofac;
using Validata.Domain.Repositories;
using Validata.Infrastructure.Repositories;

namespace Validata.API.AutofacModules
{
    public class PersistenceModule : Module
    {
        public PersistenceModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerManagerRepository>().As<ICustomerManagerRepository>().InstancePerLifetimeScope();
        }
    }
}
