using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlMag.Manufacture.DataAccess.Models;

namespace OlMag.Manufacture.DataAccess.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.Course).WithMany(c => c.Lessons).HasForeignKey(l=>l.CourseId);
        }
    }
}
