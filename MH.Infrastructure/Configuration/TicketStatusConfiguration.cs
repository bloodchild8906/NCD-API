using MH.Domain.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MH.Infrastructure.Configuration;

public class TicketStatusConfiguration : IEntityTypeConfiguration<TicketStatus>
{
    public void Configure(EntityTypeBuilder<TicketStatus> builder)
    {
        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
        builder.Property(x => x.Name)
            .HasMaxLength(250);
    }
}