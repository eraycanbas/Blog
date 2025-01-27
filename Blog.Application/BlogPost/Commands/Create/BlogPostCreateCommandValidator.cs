using FluentValidation;

namespace Blog.Application.BlogPost.Commands.Create
{
    public class BlogPostCreateCommandValidator : AbstractValidator<BlogPostCreateCommand>
    {
        public BlogPostCreateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MinimumLength(10).WithMessage("Content must be at least 10 characters long.");

            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("AuthorId is required.");
        }
    }
}