using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Validata.Domain.Domain;
using Validata.Domain.Repositories;

namespace Validata.Infrastructure.Repositories
{
    public class CustomerManagerRepository : Repository<CustomerManager>, ICustomerManagerRepository
    {
        public CustomerManagerRepository(ValidataDbContext context) :base (context)
        {
        }

        public  Task<CustomerManager> FindFirstAsync(Expression<Func<CustomerManager, bool>> filter = null)
        {

            return base.FindFirstAsync(filter);
        }
    }
}
