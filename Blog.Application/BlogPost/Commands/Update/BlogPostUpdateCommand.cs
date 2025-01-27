namespace Blog.Application.BlogPost.Commands.Update
{
    public class BlogPostUpdateCommand
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}