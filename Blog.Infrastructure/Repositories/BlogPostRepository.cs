using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class BlogPostRepository : IRepository<BlogPost>
    {
        private readonly BlogDbContext _dbContext;

        public BlogPostRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(BlogPost entity)
        {
            await _dbContext.BlogPosts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.BlogPosts.FindAsync(id);
            if (entity != null)
            {
                _dbContext.BlogPosts.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
            return await _dbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _dbContext.BlogPosts.FindAsync(id);
        }

        public async Task UpdateAsync(BlogPost entity)
        {
            _dbContext.BlogPosts.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
