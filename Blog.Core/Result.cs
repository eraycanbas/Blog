namespace Blog.Core
{
    public sealed class Result
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        private Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static Result Ok(string message = "") => new(true, message);

        public static Result Fail(string message) => new(false, message);
    }
}