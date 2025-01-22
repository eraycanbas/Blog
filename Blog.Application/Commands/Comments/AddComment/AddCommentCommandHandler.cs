using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Commands.Comments.AddComment
{
    public class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(AddCommentCommand command)
        {
            var blogPostRepository = _unitOfWork.Repository<BlogPost>();
            var blogPost = await blogPostRepository.GetByIdAsync(command.BlogPostId) ?? throw new Exception("Blog post not found.");
            var comment = new Comment(command.CommentText, command.BlogPostId);
            blogPost.AddComment(comment);
            await blogPostRepository.UpdateAsync(blogPost);
        }
    }
}