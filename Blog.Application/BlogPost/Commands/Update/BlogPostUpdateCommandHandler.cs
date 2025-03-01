using Blog.Core;
using Blog.Domain.Entities;
using MediatR;

namespace Blog.Application.BlogPost.Commands.Update
{
    public class BlogPostUpdateCommandHandler : IRequestHandler<BlogPostUpdateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogPostUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(BlogPostUpdateCommand command, CancellationToken cancellationToken)
        {
            var blogPostRepository = _unitOfWork.Repository<BlogPostEntity>();
            var blogPost = await blogPostRepository.GetByIdAsync(command.BlogPostId, cancellationToken);
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