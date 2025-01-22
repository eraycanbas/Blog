using Blog.Core;

namespace Blog.Domain.Entities
{
    public class BlogPost : BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public int AuthorId { get; private set; }
        public List<Comment> Comments { get; private set; } = new();

        public BlogPost(string title, string content, int authorId)
        {
            Title = title;
            Content = content;
            AuthorId = authorId;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
            UpdateTimestamp();
        }
    }
}