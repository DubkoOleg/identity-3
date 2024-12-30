using Microsoft.EntityFrameworkCore;
using OlMag.Manufacture.Persistece.Configurations;
using OlMag.Manufacture.Persistece.Entities;

namespace OlMag.Manufacture.Persistece
{
    public class ManufactureDbContext(DbContextOptions<ManufactureDbContext> options) : DbContext(options) {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
