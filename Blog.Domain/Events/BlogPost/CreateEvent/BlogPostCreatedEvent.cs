using Blog.Core;
using MediatR;

namespace Blog.Domain.Events.BlogPost.CreateEvent
{
    public class BlogPostCreatedEvent : IDomainEvent, INotification
    {
        public int BlogPostId { get; }
        public string Title { get; }
        public int AuthorId { get; }

        public BlogPostCreatedEvent(int blogPostId, string title, int authorId)
        {
            BlogPostId = blogPostId;
            Title = title;
            AuthorId = authorId;
        }
    }
}
