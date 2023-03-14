using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Models;

namespace University.Infrastructure.Configurations.Configs
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.CourseId);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Courses);

            builder.Property(x => x.CourseName).IsRequired();
            builder.Property( x => x.Unit).IsRequired();

        }
    }
}
