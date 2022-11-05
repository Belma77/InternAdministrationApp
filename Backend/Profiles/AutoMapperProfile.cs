using AutoMapper;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Applications, GetApplicationDto>();
            CreateMap<Selection, GetSelectionDto>();

        }
    }
}
