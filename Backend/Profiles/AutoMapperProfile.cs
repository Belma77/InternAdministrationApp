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
            CreateMap<GetAppDto, Applications>();
            CreateMap<Selection, AddSelectionDto>();
            CreateMap<AddSelectionDto, Selection>();
            CreateMap<Selection, GetSelectionDto>();
            CreateMap<Selection, GetSelectionsDto>();
            CreateMap<GetSelectionsDto, Selection>();

            CreateMap<Comment, GetCommentDto>();
            CreateMap<GetCommentDto, Comment>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, GetUsersDto>();







        }
    }
}
