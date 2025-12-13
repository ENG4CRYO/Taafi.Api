using AutoMapper;
using Taafi.Application.Dtos;

public class TaafiProfile : Profile
{
    public TaafiProfile()
    {
        CreateMap<RegisterModel, ApplicationUser>();
        CreateMap<AuthModel, ApplicationUser>();
        CreateMap<ApplicationUser, AuthModel>();
        CreateMap<Doctor, DoctorDto>();
    }
}

