namespace Core.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Core.Entities;

    public interface IRepository<T, TKey>
        where T : BaseEntity<TKey>
    {
        // Create
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        // Read
        Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default);

        IQueryable<T> ListAllAsyncAsQuery(); // ??? do I need this one?

        Task<T> GetByIdAsync(int id);

        Task<int> CountAsync();

        Task<T> FirstAsync();

        Task<T> FirstOrDefaultAsync();

        // Update
        Task UpdateAsync(T entity);

        // Delete
        Task DeleteAsync(T entity);
    }
}
