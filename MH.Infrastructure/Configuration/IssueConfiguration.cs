using MH.Domain.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MH.Infrastructure.Configuration;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
        builder.Property(x => x.Name)
            .HasMaxLength(250);
    }
}