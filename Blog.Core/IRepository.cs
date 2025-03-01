namespace Blog.Core
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id, CancellationToken cancellationToken);

        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    }
}