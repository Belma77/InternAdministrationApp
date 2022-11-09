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
            CreateMap<AddApplicationDto, Applications>();

            CreateMap<Selection, GetSelectionDto>();
            CreateMap<Selection, GetSelectionsDto>();
            CreateMap<Comment, GetCommentDto>();
            CreateMap<GetCommentDto, Comment>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();




        }
    }
}
