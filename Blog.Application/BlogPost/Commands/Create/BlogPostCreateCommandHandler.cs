using Blog.Core;
using Blog.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Blog.Application.BlogPost.Commands.Create
{
    public class BlogPostCreateCommandHandler : IRequestHandler<BlogPostCreateCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<BlogPostCreateCommand> _validator;

        public BlogPostCreateCommandHandler(IUnitOfWork unitOfWork, IValidator<BlogPostCreateCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<int> Handle(BlogPostCreateCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var blogPostRepository = _unitOfWork.Repository<BlogPostEntity>();
            var blogPost = new BlogPostEntity(
                request.Title,
                request.Content,
                request.AuthorId);

            await blogPostRepository.AddAsync(blogPost);
            await _unitOfWork.CommitAsync();
            return blogPost.Id;
        }
    }
}