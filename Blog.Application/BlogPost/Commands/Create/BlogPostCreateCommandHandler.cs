using Blog.Core;
using Blog.Domain.Entities;
using Blog.Domain.Events.BlogPost.CreateEvent;
using FluentValidation;
using MediatR;

namespace Blog.Application.BlogPost.Commands.Create
{
    public class BlogPostCreateCommandHandler : IRequestHandler<BlogPostCreateCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<BlogPostCreateCommand> _validator;
        private readonly IMediator _mediator;

        public BlogPostCreateCommandHandler(IUnitOfWork unitOfWork,
                                            IValidator<BlogPostCreateCommand> validator,
                                            IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mediator = mediator;
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

            await blogPostRepository.AddAsync(blogPost, cancellationToken);
            await _unitOfWork.CommitAsync();

            var blogPostCreatedEvent = new BlogPostCreatedEvent(blogPost.Id, blogPost.Title, blogPost.AuthorId);
            await _mediator.Publish(blogPostCreatedEvent, cancellationToken);

            return blogPost.Id;
        }
    }
}