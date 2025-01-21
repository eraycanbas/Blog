namespace Blog.Application.Commands.BlogPosts.CreateBlogPost
{
    public class CreateBlogPostCommand
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
    }
}
