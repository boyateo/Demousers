namespace Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Core.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class EFRepository<T> : IRepository<T>
        where T : class
    {
        private readonly EfMSQLContext dbContext;

        public EFRepository(EfMSQLContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await this.dbContext.Set<T>().AddAsync(entity);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
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

        public async Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.dbContext.Set<T>().ToListAsync(cancellationToken);

            return result;
        }

        public Task<IReadOnlyList<T>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            await this.dbContext.SaveChangesAsync();
        }
    }
}
