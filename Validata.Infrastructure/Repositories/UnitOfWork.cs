using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Validata.Domain.Repositories;

namespace Validata.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ValidataDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(ValidataDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
