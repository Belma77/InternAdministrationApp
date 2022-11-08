using AutoMapper;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Applications, GetApplicationsDto>();
            CreateMap<Applications, GetAppDto>();
            CreateMap<Selection, GetSelectionDto>();
            CreateMap<Selection, GetSelectionsDto>();
            CreateMap<Comment, GetCommentDto>();
            CreateMap<AddApplicationDto,Applications>();



        }
    }
}
