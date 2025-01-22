using Blog.Core;

namespace Blog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; private set; }
        public int BlogPostId { get; private set; }

        public Comment(string text, int blogPostId)
        {
            Text = text;
            BlogPostId = blogPostId;
        }
    }
}