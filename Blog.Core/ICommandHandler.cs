namespace Blog.Core
{
    public interface ICommandHandler<TCommand>
    {
        Task HandleAsync(TCommand command);
    }
}