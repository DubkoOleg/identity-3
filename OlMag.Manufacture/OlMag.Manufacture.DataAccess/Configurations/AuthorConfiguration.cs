using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlMag.Manufacture.DataAccess.Models;

namespace OlMag.Manufacture.DataAccess.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a=>a.Course).WithOne(c => c.Author).HasForeignKey<AuthorEntity>(a=>a.CourseId);
        }
    }
}
