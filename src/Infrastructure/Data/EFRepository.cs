namespace Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class EFRepository<T, TKey> : IRepository<T, TKey>
        where T : BaseEntity<TKey>
    {
        private readonly EfMSQLContext dbContext;

        public EFRepository(EfMSQLContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Create
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await this.dbContext.Set<T>().AddAsync(entity);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        // Read
        // TODO: Most developers suggest not to return IQueryable from a repository!
        // But what if we use a service aswell it through a service? Use private modifyer?
        // TODO: return IQueryable maybe?
        public async Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.dbContext.Set<T>().ToListAsync(cancellationToken);

            return result;
        }

        // TODO: how to encapsulate this method and where? Here or in the service so it is not exposed in the app everywhere.
        public IQueryable<T> ListAllAsyncAsQuery()
        {
            var query = this.dbContext.Set<T>();

            return query;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        // Update
        public async Task UpdateAsync(T entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            await this.dbContext.SaveChangesAsync();
        }

        // Delete
        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
