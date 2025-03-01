using MediatR;

namespace Blog.Application.BlogPost.Commands.Delete
{
    public class BlogPostDeleteCommand: IRequest
    {
        public int BlogPostId { get; set; }
    }
}