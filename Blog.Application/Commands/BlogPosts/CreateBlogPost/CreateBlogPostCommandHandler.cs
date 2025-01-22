using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Commands.BlogPosts.CreateBlogPost
{
    public class CreateBlogPostCommandHandler : ICommandHandler<CreateBlogPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBlogPostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CreateBlogPostCommand command)
        {
            var blogPostRepository = _unitOfWork.Repository<BlogPost>();
            var blogPost = new BlogPost(command.Title, command.Content, command.AuthorId);
            await blogPostRepository.AddAsync(blogPost);
            await _unitOfWork.CommitAsync();

        }
    }
}
