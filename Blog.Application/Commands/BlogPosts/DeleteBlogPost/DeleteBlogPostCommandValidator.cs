using FluentValidation;

namespace Blog.Application.Commands.BlogPosts.DeleteBlogPost
{
    public class DeleteBlogPostCommandValidator : AbstractValidator<DeleteBlogPostCommand>
    {
        public DeleteBlogPostCommandValidator()
        {
            RuleFor(x => x.BlogPostId)
                .NotEmpty().WithMessage("AuthorId is required.");
        }
    }
}