namespace Blog.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IAggregateRoot;

        Task<int> CommitAsync();
    }
}