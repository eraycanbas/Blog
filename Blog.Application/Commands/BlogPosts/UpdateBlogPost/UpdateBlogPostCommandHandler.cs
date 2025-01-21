using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Commands.BlogPosts.UpdateBlogPost
{
    public class UpdateBlogPostCommandHandler : ICommandHandler<UpdateBlogPostCommand>
    {
        private readonly IRepository<BlogPost> _repository;

        public UpdateBlogPostCommandHandler(IRepository<BlogPost> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateBlogPostCommand command)
        {
            var blogPost = await _repository.GetByIdAsync(command.BlogPostId);
            if (blogPost == null)
                throw new Exception("Blog post not found.");

            blogPost.GetType().GetProperty("Title")?.SetValue(blogPost, command.Title);
            blogPost.GetType().GetProperty("Content")?.SetValue(blogPost, command.Content);
            blogPost.UpdateTimestamp();

            await _repository.UpdateAsync(blogPost);
        }
    }
}