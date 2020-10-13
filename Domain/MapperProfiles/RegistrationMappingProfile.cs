using AutoMapper;
 using Domain;
 using Domain.Dtos;

 namespace AlliedTestingTask.Data.MapperProfiles
{
    public class RegistrationMappingProfile: Profile
    {
        public RegistrationMappingProfile()
        {
            CreateMap<Registration, RegistrationDto>();
            CreateMap<RegistrationDto, Registration>();
        }
    }
}