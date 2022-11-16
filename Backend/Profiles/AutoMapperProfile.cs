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
            CreateMap<Selection, EditSelectionDto>();
            CreateMap<EditSelectionDto, Selection>();

            CreateMap<AddSelectionDto, Selection>();
            CreateMap<Selection, GetSelectionDto>()
                .ForMember(x=>x.DateCreated, y=>y.MapFrom(z=>z.CreatedAt))
                .ForMember(i=>i.DateEdited, j=>j.MapFrom(k=>k.EditedAt));
            CreateMap<Selection, GetSelectionsDto>();
            CreateMap<GetSelectionsDto, Selection>();

            CreateMap<Comment, GetCommentDto>();
            CreateMap<GetCommentDto, Comment>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, GetUsersDto>();

            CreateMap<AddAppComment, Comment>();
            CreateMap<Comment, AddAppComment>();
            CreateMap<Comment, AddSelectionComment>();
            CreateMap<AddSelectionComment,Comment>();




        }
    }
}
