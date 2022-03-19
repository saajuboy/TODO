using AutoMapper;
using TODO.API.Dtos;

namespace TODO.API.Models.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<NotesHeader, NoteDto>();
            CreateMap<NotesDetail, NoteDetailDto>().ForMember(dest => dest.NoteId, opt =>
            {
                opt.MapFrom(src => src.NotesHeaderId);
            });

            CreateMap<NoteDto, NotesHeader>();
            CreateMap<NoteDetailDto, NotesDetail>().ForMember(dest => dest.NotesHeaderId, opt =>
            {
                opt.MapFrom(src => src.NoteId);
            });

            CreateMap<NoteForUpdateDto,NotesHeader >().ForMember(dest => dest.Description, opt =>
            {
                opt.MapFrom(src => src.Description);
            });
            CreateMap<NoteDetailForUpdateDto,NotesDetail >()
            .ForMember(dest => dest.Description, opt =>
            {
                opt.MapFrom(src => src.Description);
            })
            .ForMember(dest => dest.Title, opt =>
            {
                opt.MapFrom(src => src.Title);
            })
            .ForMember(dest => dest.Status, opt =>
            {
                opt.MapFrom(src => src.Status);
            })
            .ForMember(dest => dest.Archived, opt =>
            {
                opt.MapFrom(src => src.Archived);
            });
        }
    }
}