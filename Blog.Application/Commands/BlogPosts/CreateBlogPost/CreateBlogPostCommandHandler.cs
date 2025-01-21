using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Commands.BlogPosts.CreateBlogPost
{
    public class CreateBlogPostCommandHandler : ICommandHandler<CreateBlogPostCommand>
    {
        private readonly IRepository<BlogPost> _repository;

        public CreateBlogPostCommandHandler(IRepository<BlogPost> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(CreateBlogPostCommand command)
        {
            var blogPost = new BlogPost(command.Title, command.Content, command.AuthorId);
            await _repository.AddAsync(blogPost);
        }
    }
}
