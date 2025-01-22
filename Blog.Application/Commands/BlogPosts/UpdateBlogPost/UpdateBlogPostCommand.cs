namespace Blog.Application.Commands.BlogPosts.UpdateBlogPost
{
    public class UpdateBlogPostCommand
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}