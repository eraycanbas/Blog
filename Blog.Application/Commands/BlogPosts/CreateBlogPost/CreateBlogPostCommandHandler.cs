using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using FluentValidation;

namespace Blog.Application.Commands.BlogPosts.CreateBlogPost
{
    public class CreateBlogPostCommandHandler : ICommandHandler<CreateBlogPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateBlogPostCommand> _validator;


        public CreateBlogPostCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateBlogPostCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task HandleAsync(CreateBlogPostCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var blogPostRepository = _unitOfWork.Repository<BlogPost>();
            var blogPost = new BlogPost(
                command.Title,
                command.Content,
                command.AuthorId);

            await blogPostRepository.AddAsync(blogPost);
            await _unitOfWork.CommitAsync();
        }
    }
}