using MediatR;

namespace Blog.Application.BlogPost.Commands.Update
{
    public class BlogPostUpdateCommand: IRequest
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}