using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Blog.Application.Commands.BlogPosts.CreateBlogPost
{
    public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateBlogPostCommand> _validator;

        public CreateBlogPostCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateBlogPostCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<int> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var blogPostRepository = _unitOfWork.Repository<BlogPost>();
            var blogPost = new BlogPost(
                request.Title,
                request.Content,
                request.AuthorId);

            await blogPostRepository.AddAsync(blogPost);
            await _unitOfWork.CommitAsync();
            return blogPost.Id;
        }

    }
}