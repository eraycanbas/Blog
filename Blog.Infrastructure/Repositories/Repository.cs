using Blog.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Blog.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken) != null;
        }
    }
}