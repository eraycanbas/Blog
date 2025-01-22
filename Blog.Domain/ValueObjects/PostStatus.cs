namespace Blog.Domain.ValueObjects
{
    public sealed class PostStatus
    {
        public string Value { get; private set; }

        private PostStatus(string value)
        {
            Value = value;
        }

        public static PostStatus Draft => new("Draft");
        public static PostStatus Published => new("Published");
    }
}