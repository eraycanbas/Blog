using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;

namespace Blog.Infrastructure.Repositories
{
    public class BlogPostRepository : EfRepository<BlogPost>
    {
        private readonly BlogDbContext _dbContext;

        public BlogPostRepository(BlogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
