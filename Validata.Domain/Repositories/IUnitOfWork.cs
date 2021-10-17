using System;
using System.Threading.Tasks;

namespace Validata.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
