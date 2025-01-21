using Blog.Core;

namespace Blog.Domain.Events
{
    public class CommentAddedEvent : IDomainEvent
    {
        public int CommentId { get; private set; }

        public CommentAddedEvent(int commentId)
        {
            CommentId = commentId;
        }
    }
}
