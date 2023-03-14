using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Models;

namespace University.Infrastructure.Configurations.Configs
{
    public class SelectUnitConfiguration : IEntityTypeConfiguration<SelectUnit>
    {
        public void Configure(EntityTypeBuilder<SelectUnit> builder)
        {
            builder.HasKey(x => x.SelectUnitId);

            builder.Property(x => x.Limit).IsRequired();
        }
    }
}
