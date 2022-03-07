using AutoMapper;
using TODO.API.Dtos;

namespace TODO.API.Models.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<NotesHeader, NoteDto>();
            CreateMap<NotesDetail, NoteDetailDto>();

        }
    }
}