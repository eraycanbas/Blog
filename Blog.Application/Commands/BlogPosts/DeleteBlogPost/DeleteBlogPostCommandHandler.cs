using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Commands.BlogPosts.DeleteBlogPost
{
    public class DeleteBlogPostCommandHandler : ICommandHandler<DeleteBlogPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBlogPostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteBlogPostCommand command)
        {
            var blogPostRepository = _unitOfWork.Repository<BlogPost>();
            var blogPost = await blogPostRepository.GetByIdAsync(command.BlogPostId);
            if (blogPost == null)
                throw new Exception("Blog post not found.");

            await blogPostRepository.DeleteAsync(command.BlogPostId);
            await _unitOfWork.CommitAsync();
        }
    }
}