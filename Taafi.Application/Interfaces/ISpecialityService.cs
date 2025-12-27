using System;
using System.Collections.Generic;
using System.Text;
using Taafi.Application.Dtos;

namespace Taafi.Application.Interfaces
{
    public interface ISpecialityService
    {
        Task<ServiceResponse<ICollection<SpecialtyDto>>> GetAllSpecialtiesAsync();
        Task<ServiceResponse<ICollection<DoctorDto>>> GetDoctorDtosAsync(string specialtyId);
    }
}
