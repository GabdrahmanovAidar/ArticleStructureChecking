using Microsoft.EntityFrameworkCore;

namespace ArticlesStructureChecking.Infrastructure.DataAccess
{
    public class ArticlesStructureCheckingDbContext : DbContext
    {
        public ArticlesStructureCheckingDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticlesStructureCheckingDbContext).Assembly);
        }
    }
}
