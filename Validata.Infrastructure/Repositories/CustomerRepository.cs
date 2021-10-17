using System;
using Microsoft.Extensions.Logging;
using Validata.Domain.Domain;
using Validata.Domain.Repositories;

namespace Validata.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ValidataDbContext context) : base(context)
        {

        }
    }
}
