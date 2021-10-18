using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Validata.Domain.Repositories;

namespace Validata.Infrastructure.Repositories
{
    public class Repository<T>  :  IRepository<T> where T: class
    {
        protected ValidataDbContext _context;
        //internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public Repository(ValidataDbContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _context.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return null;
        }

        public Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return null;
        }
    }
}
