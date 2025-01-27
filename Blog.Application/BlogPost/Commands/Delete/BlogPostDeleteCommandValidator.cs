using FluentValidation;

namespace Blog.Application.BlogPost.Commands.Delete
{
    public class BlogPostDeleteCommandValidator : AbstractValidator<BlogPostDeleteCommand>
    {
        public BlogPostDeleteCommandValidator()
        {
            RuleFor(x => x.BlogPostId)
                .NotEmpty().WithMessage("AuthorId is required.");
        }
    }
}