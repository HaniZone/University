using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Models;

namespace University.Infrastructure.Configurations.Configs
{
    public class SelectUnitCourseConfiguration : IEntityTypeConfiguration<SelectUnitCourse>
    {
        public void Configure(EntityTypeBuilder<SelectUnitCourse> builder)
        {
            builder.HasKey(x => x.SelectUnitCourseId);
            builder.HasOne(x => x.SelectUnit).WithMany(x => x.SelectUnitCourses);
            builder.HasOne(x => x.Course).WithMany(x => x.SelectUnitCourses);
        }
    }

}
