using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taafi.Application.Interfaces;


public class AppDbContext(DbContextOptions<AppDbContext> options) :
    IdentityDbContext<ApplicationUser>(options),
    IAppDbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Seed();
        }


    public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; } 
        public DbSet<Notification> Notifications { get; set; }
        
        public DbSet<ChatMessage> ChatMessages { get; set; }    
}

