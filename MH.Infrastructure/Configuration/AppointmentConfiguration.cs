using MH.Domain.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MH.Infrastructure.Configuration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasIndex(x => x.CreatedBy)
            .IsUnique(false);
        builder.HasIndex(x => x.UpdatedBy)
            .IsUnique(false);
        builder.HasIndex(x => x.PatientId)
            .IsUnique(false);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);


        builder.HasOne(x => x.Patient)
            .WithMany(y => y.Appointment)
            .HasForeignKey(z => z.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.CreatedByUser)
            .WithOne(y => y.CreatedByAppointment)
            .HasForeignKey<Appointment>(z => z.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.UpdateByUser)
            .WithOne(y => y.UpdatedByAppointment)
            .HasForeignKey<Appointment>(z => z.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}