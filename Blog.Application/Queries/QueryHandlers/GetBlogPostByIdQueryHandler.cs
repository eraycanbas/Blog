using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Queries.QueryHandlers
{
    public class GetBlogPostByIdQueryHandler : IQueryHandler<GetBlogPostByIdQuery, BlogPost>
    {
        private readonly IRepository<BlogPost> _repository;

        public GetBlogPostByIdQueryHandler(IRepository<Domain.Entities.BlogPost> repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.BlogPost> HandleAsync(GetBlogPostByIdQuery query)
        {
            return await _repository.GetByIdAsync(query.BlogPostId);
        }
    }
}