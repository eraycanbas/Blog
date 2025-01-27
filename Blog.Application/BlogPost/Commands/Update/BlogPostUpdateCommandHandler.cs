using Blog.Core;
using Blog.Domain.Entities;

namespace Blog.Application.BlogPost.Commands.Update
{
    public class BlogPostUpdateCommandHandler : ICommandHandler<BlogPostUpdateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogPostUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(BlogPostUpdateCommand command)
        {
            var blogPostRepository = _unitOfWork.Repository<BlogPostEntity>();
            var blogPost = await blogPostRepository.GetByIdAsync(command.BlogPostId);
            if (blogPost == null)
                throw new Exception("Blog post not found.");

            blogPost.GetType().GetProperty("Title")?.SetValue(blogPost, command.Title);
            blogPost.GetType().GetProperty("Content")?.SetValue(blogPost, command.Content);
            blogPost.UpdateTimestamp();

            await blogPostRepository.UpdateAsync(blogPost);
            await _unitOfWork.CommitAsync();
        }
    }
}