using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;

namespace Blog.Infrastructure.Repositories
{
    public class BlogPostRepository : Repository<BlogPostEntity>
    {
        private readonly BlogDbContext _dbContext;

        public BlogPostRepository(BlogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}