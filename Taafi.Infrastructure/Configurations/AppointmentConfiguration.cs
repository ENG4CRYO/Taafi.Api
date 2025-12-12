using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.AppointmentDate)
            .IsRequired();

        builder.Property(a => a.AppointmentTime)
            .IsRequired();

        builder.Property(a => a.QueueNumber)
            .IsRequired();

        builder.Property(a => a.Status)
            .IsRequired();

        builder.Property(a => a.PatientNotes)
            .HasMaxLength(1000);

      


    }
}

