using AutoMapper;
using Sant_George.DTOs.Auth;
using Sant_George.Models.User;

namespace Sant_George.Mappers
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();
            CreateMap<LoginDTO, ApplicationUser>().ReverseMap();

        }
    }
}
