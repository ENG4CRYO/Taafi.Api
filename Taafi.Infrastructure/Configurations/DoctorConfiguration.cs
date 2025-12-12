using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Bio)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(d => d.Location)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.Rate)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(d => d.ExperienceYears)
            .IsRequired();

        builder.Property(d => d.ImageUrl)
            .IsRequired()
            .HasMaxLength(200);


        builder.Property(d => d.IsActive)
            .IsRequired();

        builder.HasOne(d => d.Specialty)
            .WithMany(s => s.Doctors)
            .HasForeignKey(d => d.SpecialtyId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasMany(d => d.DoctorShedules)
            .WithOne(ds => ds.Doctor)
            .HasForeignKey(ds => ds.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Appointment)
            .WithMany(a => a.Doctors)
            .HasForeignKey(d => d.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

