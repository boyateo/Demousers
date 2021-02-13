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
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default);

        IQueryable<T> ListAllAsyncAsQuery();

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<int> CountAsync();

        Task<T> FirstAsync();

        Task<T> FirstOrDefaultAsync();
    }
}
