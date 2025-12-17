using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taafi.Application.Dtos;
using Taafi.Application.Interfaces;

namespace Taafi.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public DoctorService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
                        
        public async Task<DoctorDto> GetDoctorByIdAsync(string id)
        {
            var doctor = await _context.Doctors
                .Where(d => d.Id == id)
                .ProjectTo<DoctorDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (doctor == null) return null!;

            return doctor;
        }

        public async Task<List<DoctorDto>> GetDoctorsAsync(string? search, string? specialtyId)
        {
            var query = _context.Doctors.AsQueryable();

            query = query.Include(d => d.Specialty);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(d => d.Name.Contains(search));
            }
            if(!string.IsNullOrWhiteSpace(specialtyId))
            {
                query = query.Where(d => d.SpecialtyId ==  specialtyId);
            }

            var doctors = await query
                .ProjectTo<DoctorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return doctors;
        }

        public async Task<List<DoctorScheduleDto>> GetDoctorScheduleAsync(string doctorId)
        {
            var schedules = await _context.DoctorSchedules
                .Where(s => s.DoctorId == doctorId)
                .ToListAsync();

            return schedules.Select(s => new DoctorScheduleDto
            {
                DayOfWeek = s.DayOfWeek.ToString(),
                StartTime = s.StartTime.ToString("HH:mm"),
                EndTime = s.EndTime.ToString("HH:mm"),
                IsAvailable = s.IsAvailable
            }).ToList();
        }
    }
}
