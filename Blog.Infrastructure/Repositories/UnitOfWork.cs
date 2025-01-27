using Blog.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>() where T : class, IAggregateRoot
        {
            return new Repository<T>(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}