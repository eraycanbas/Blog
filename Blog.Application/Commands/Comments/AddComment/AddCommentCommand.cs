namespace Blog.Application.Commands.Comments.AddComment
{
    public class AddCommentCommand
    {
        public int BlogPostId { get; set; }
        public string CommentText { get; set; }
    }
}
