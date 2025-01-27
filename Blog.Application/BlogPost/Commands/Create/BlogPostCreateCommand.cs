using MediatR;

namespace Blog.Application.BlogPost.Commands.Create
{
    public class BlogPostCreateCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
    }
}