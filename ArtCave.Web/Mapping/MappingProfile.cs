using ArtCave.Data.Entities;
using ArtCave.Web.DTO.Registration;
using AutoMapper;

namespace ArtCave.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationRequest, ApplicationUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
