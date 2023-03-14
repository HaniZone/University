using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Models;

namespace University.Infrastructure.Configurations.Configs
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);
            builder.HasMany(x => x.Users).WithOne(x => x.Student).IsRequired(false);
        }
    }
}