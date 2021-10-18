using System;
using Validata.Domain.Domain;
using Validata.Domain.Repositories;

namespace Validata.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ValidataDbContext context) :base(context)
        {
        }
    }
}
