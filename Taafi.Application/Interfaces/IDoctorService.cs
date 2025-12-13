using System.Collections.Generic;
using Taafi.Application.Dtos;

public interface IDoctorService
{
    Task <List<DoctorDto>> GetDoctorsAsync(string? search, string? specialtyId);
    Task<DoctorDto> GetDoctorByIdAsync(string id);
}

