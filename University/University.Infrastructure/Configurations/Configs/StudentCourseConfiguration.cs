using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Models;

namespace University.Infrastructure.Configurations.Configs
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Student).WithMany(x => x.StudentCourses).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Course).WithMany(x => x.StudentCourses).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
