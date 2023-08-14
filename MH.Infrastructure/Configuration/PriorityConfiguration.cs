using MH.Domain.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MH.Infrastructure.Configuration;

public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
{
    public void Configure(EntityTypeBuilder<Priority> builder)
    {
        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
        builder.Property(x => x.Name)
            .HasMaxLength(250);
    }
}