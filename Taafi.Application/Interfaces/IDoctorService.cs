using System.Collections.Generic;
using Taafi.Application.Dtos;

public interface IDoctorService
{
    Task <ServiceResponse<List<DoctorDto>>> GetDoctorsAsync(string? search, string? specialtyId);
    Task <ServiceResponse<DoctorDto>> GetDoctorByIdAsync(string id);

    Task <ServiceResponse<List<DoctorScheduleDto>>> GetDoctorScheduleAsync(string doctorId);
}

