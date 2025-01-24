using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using FluentValidation;

namespace Blog.Application.Commands.BlogPosts.DeleteBlogPost
{
    public class DeleteBlogPostCommandHandler : ICommandHandler<DeleteBlogPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<DeleteBlogPostCommand> _validator;

        public DeleteBlogPostCommandHandler(IUnitOfWork unitOfWork , IValidator<DeleteBlogPostCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task HandleAsync(DeleteBlogPostCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var blogPostRepository = _unitOfWork.Repository<BlogPost>();
            var blogPost = await blogPostRepository.GetByIdAsync(command.BlogPostId);
            if (blogPost == null)
                throw new Exception("Blog post not found.");

            await blogPostRepository.DeleteAsync(command.BlogPostId);
            await _unitOfWork.CommitAsync();
        }
    }
}