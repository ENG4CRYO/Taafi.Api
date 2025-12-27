using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taafi.Application.Dtos;
using Taafi.Application.Interfaces;

namespace Taafi.Application.Services
{
    internal class SpecialityService : ISpecialityService
    {
        private readonly IAppDbContext _context;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        public SpecialityService(IAppDbContext context, IDoctorService doctorService, IMapper mapper)
        {
            _context = context;
            _doctorService = doctorService;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ICollection<SpecialtyDto>>> GetAllSpecialtiesAsync()
        {
            var specialties = await _context.Specialties.ToListAsync();
            var response = new ServiceResponse<ICollection<SpecialtyDto>>
            {
                Data = _mapper.Map<ICollection<SpecialtyDto>>(specialties)
            };

            return response;
        }

        public async Task<ServiceResponse<ICollection<DoctorDto>>> GetDoctorDtosAsync(string specialtyId)
        {
            var doctors = await _doctorService.GetDoctorsAsync(null, specialtyId);
            var response = new ServiceResponse<ICollection<DoctorDto>>
            {
                Data = doctors.Data
            };

            return response;
        }
    }
}
