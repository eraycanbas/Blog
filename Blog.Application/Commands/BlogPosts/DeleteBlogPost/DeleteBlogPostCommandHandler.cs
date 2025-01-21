using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Commands.BlogPosts.DeleteBlogPost
{
    public class DeleteBlogPostCommandHandler : ICommandHandler<DeleteBlogPostCommand>
    {
        private readonly IRepository<BlogPost> _repository;

        public DeleteBlogPostCommandHandler(IRepository<BlogPost> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteBlogPostCommand command)
        {
            var blogPost = await _repository.GetByIdAsync(command.BlogPostId);
            if (blogPost == null)
                throw new Exception("Blog post not found.");

            await _repository.DeleteAsync(command.BlogPostId);
        }
    }
}