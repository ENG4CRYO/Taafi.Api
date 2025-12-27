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
        CreateMap<CreateAppointmentDto, Appointment>();

        CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
                .ForMember(dest => dest.DoctorImage, opt => opt.MapFrom(src => src.Doctor.ImageUrl))
                .ForMember(dest => dest.SpecialtyName, opt => opt.MapFrom(src => src.Doctor.Specialty.Name));

        CreateMap<ChatMessage, ChatMessageDto>();
        CreateMap<Notification, NotificationDto>();

        CreateMap<Specialty, SpecialtyDto>();
    }
}

