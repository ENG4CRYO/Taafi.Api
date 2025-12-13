using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taafi.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Doctor> Doctors { get; }
        DbSet<Specialty> Specialties { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        DbSet<Notification> Notifications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
