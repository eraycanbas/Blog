using Blog.Core;

namespace Blog.Domain.Events
{
    public class BlogPostCreatedEvent : IDomainEvent
    {
        public int BlogPostId { get; private set; }

        public BlogPostCreatedEvent(int blogPostId)
        {
            BlogPostId = blogPostId;
        }
    }
}
