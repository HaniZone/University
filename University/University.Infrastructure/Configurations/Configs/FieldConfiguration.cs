using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Models;

namespace University.Infrastructure.Configurations.Configs
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(x => x.FieldId);
            builder.HasMany(x => x.Students).WithOne(x => x.Field);

            builder.Property(x => x.FieldName).IsRequired();
            builder.Property(x => x.SectionName).IsRequired();
            builder.Property(x => x.MaxUnit).IsRequired().HasMaxLength(24);
            builder.Property(x => x.MinUnit).IsRequired();
        }
    }
}
