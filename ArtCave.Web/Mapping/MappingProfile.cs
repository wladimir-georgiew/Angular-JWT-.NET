using ArtCave.Web.Data.Entities;
using ArtCave.Web.DTO.Admin.Categories;
using ArtCave.Web.DTO.Registration;
using AutoMapper;

namespace ArtCave.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationRequest, ApplicationUser>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<CreateCategoryRequest ,Category>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.CategoryName));
        }
    }
}
