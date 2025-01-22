namespace Blog.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }

        public void UpdateTimestamp() => UpdatedAt = DateTime.UtcNow;
    }
}