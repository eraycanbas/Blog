using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Commands.BlogPosts.UpdateBlogPost
{
    public class UpdateBlogPostCommandHandler : ICommandHandler<UpdateBlogPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBlogPostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(UpdateBlogPostCommand command)
        {
            var blogPostRepository = _unitOfWork.Repository<BlogPost>();
            var blogPost = await blogPostRepository.GetByIdAsync(command.BlogPostId);
            if (blogPost == null)
                throw new Exception("Blog post not found.");

            blogPost.GetType().GetProperty("Title")?.SetValue(blogPost, command.Title);
            blogPost.GetType().GetProperty("Content")?.SetValue(blogPost, command.Content);
            blogPost.UpdateTimestamp();

            await blogPostRepository.UpdateAsync(blogPost);
        }
    }
}