using Blog.Application.Interfaces;

namespace Blog.Application.Commands.Comments.AddComment
{
    public class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
    {
        private readonly IRepository<Domain.Entities.BlogPost> _repository;

        public AddCommentCommandHandler(IRepository<Domain.Entities.BlogPost> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddCommentCommand command)
        {
            var blogPost = await _repository.GetByIdAsync(command.BlogPostId);
            if (blogPost == null) throw new Exception("Blog post not found.");

            var comment = new Domain.Entities.Comment(command.CommentText, command.BlogPostId);
            blogPost.AddComment(comment);
            await _repository.UpdateAsync(blogPost);
        }
    }
}
