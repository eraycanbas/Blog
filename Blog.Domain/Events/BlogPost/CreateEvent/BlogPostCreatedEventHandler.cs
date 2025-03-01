using Blog.Core;
using MediatR;

namespace Blog.Domain.Events.BlogPost.CreateEvent
{
    public class BlogPostCreatedEventHandler : INotificationHandler<BlogPostCreatedEvent>
    {
        private readonly ILoggerService _logger;

        public BlogPostCreatedEventHandler(ILoggerService logger)
        {
            _logger = logger;
        }

        public Task Handle(BlogPostCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Yeni blog gönderisi oluşturuldu: {notification.Title} (ID: {notification.BlogPostId}, Yazar ID: {notification.AuthorId})");
            return Task.CompletedTask;
        }
    }
}