using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlMag.Manufacture.DataAccess.Models;

namespace OlMag.Manufacture.DataAccess.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s=>s.Courses).WithMany(c=>c.Students);
        }
    }
}
