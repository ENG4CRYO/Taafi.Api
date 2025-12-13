using AutoMapper;

public class TaafiProfile : Profile
{
    public TaafiProfile()
    {
        CreateMap<RegisterModel, ApplicationUser>();
        CreateMap<AuthModel, ApplicationUser>();
        CreateMap<ApplicationUser, AuthModel>();
    }
}

