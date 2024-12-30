using Microsoft.EntityFrameworkCore;
using OlMag.Manufacture.DataAccess.Configurations;
using OlMag.Manufacture.DataAccess.Models;

namespace OlMag.Manufacture.DataAccess
{
    public class LearningDbContext(DbContextOptions<LearningDbContext> options) : DbContext(options)
    {
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<StudentEntity> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
