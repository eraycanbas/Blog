using Blog.Core;
using Microsoft.Extensions.Logging;

namespace Blog.Infrastructure.Logging
{
    public class SerilogLoggerService : ILoggerService
    {
        private readonly ILogger<SerilogLoggerService> _logger;

        public SerilogLoggerService(ILogger<SerilogLoggerService> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogError(string message, Exception ex)
        {
            _logger.LogError(ex, message);
        }
    }
}
