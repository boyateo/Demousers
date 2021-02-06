namespace Infrastructure.Data
{
    using Core.Entities;
    using Microsoft.EntityFrameworkCore;

    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options)
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
