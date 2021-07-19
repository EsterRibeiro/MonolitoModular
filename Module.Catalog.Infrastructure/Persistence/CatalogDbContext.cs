using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using Shared.Infrastructure.Persistence;


namespace Module.Catalog.Infrastructure.Persistence
{
    public class CatalogDbContext : ModuleDbContext, ICatalogDbContext
    {
        public DbSet<Brand> Brands { get; set; }
        protected override string Schema => "Catalog";

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
