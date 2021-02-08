namespace Infrastructure.Data
{
    using Core.Entities;
    using Microsoft.EntityFrameworkCore;

    public class EfMSQLContext : DbContext
    {
        public EfMSQLContext(DbContextOptions<EfMSQLContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Shortcut> Shortcuts { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
