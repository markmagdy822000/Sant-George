using AutoMapper;
using Sant_George_Website.DTOs;
using SantGeorgeWebsite.Models;

namespace Sant_George_Website.Mappers
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
