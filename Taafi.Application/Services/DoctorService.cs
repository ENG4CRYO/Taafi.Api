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
                        
        public async Task<ServiceResponse<DoctorDto>> GetDoctorByIdAsync(string id)
        {

            var response = new ServiceResponse<DoctorDto>();
            var doctor = await _context.Doctors.AsNoTracking()
                .Where(d => d.Id == id)
                .ProjectTo<DoctorDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (doctor == null) return ServiceResponse<DoctorDto>.Error("Doctor not found");

             response.Data = doctor;
            return response;
        }

        public async Task<ServiceResponse<List<DoctorDto>>> GetDoctorsAsync(string? search, string? specialtyId)
        {
            var response = new ServiceResponse<List<DoctorDto>>();  
            var query = _context.Doctors.AsNoTracking().AsQueryable();

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

            response.Data = doctors;
            return response;
        }

        public async Task<ServiceResponse<List<DoctorScheduleDto>>> GetDoctorScheduleAsync(string doctorId)
        {
            var response = new ServiceResponse<List<DoctorScheduleDto>>();  
            var schedules = await _context.DoctorSchedules
                .Where(s => s.DoctorId == doctorId)
                .ToListAsync();

            response.Data =  schedules.Select(s => new DoctorScheduleDto
            {
                DayOfWeek = s.DayOfWeek.ToString(),
                StartTime = s.StartTime.ToString("HH:mm"),
                EndTime = s.EndTime.ToString("HH:mm"),
                IsAvailable = s.IsAvailable
            }).ToList();

            return response;
        }
    }
}
