using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorSheduleConfiguration : IEntityTypeConfiguration<DoctorShedule>
{
    public void Configure(EntityTypeBuilder<DoctorShedule> builder)
    {
        builder.HasKey(ds => ds.Id);

        builder.HasOne(ds => ds.Doctor)
            .WithMany(d => d.DoctorShedules)
            .HasForeignKey(ds => ds.DoctorId)
            .IsRequired();
    }
}

