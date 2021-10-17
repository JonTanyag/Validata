using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Validata.Domain.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<bool> Add(T entity);

        Task<bool> Delete(Guid id);

        Task<bool> Upsert(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetById(Guid id);
    }
}
