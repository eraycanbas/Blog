using Blog.Core;
using Blog.Domain.Entities;
using FluentValidation;

namespace Blog.Application.BlogPost.Commands.Delete
{
    public class BlogPostDeleteCommandHandler : ICommandHandler<BlogPostDeleteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<BlogPostDeleteCommand> _validator;

        public BlogPostDeleteCommandHandler(IUnitOfWork unitOfWork, IValidator<BlogPostDeleteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task HandleAsync(BlogPostDeleteCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var blogPostRepository = _unitOfWork.Repository<BlogPostEntity>();
            var blogPost = await blogPostRepository.GetByIdAsync(command.BlogPostId);
            if (blogPost == null)
                throw new Exception("Blog post not found.");

            await blogPostRepository.DeleteAsync(command.BlogPostId);
            await _unitOfWork.CommitAsync();
        }
    }
}