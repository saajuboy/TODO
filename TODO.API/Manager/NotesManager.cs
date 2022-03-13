using AutoMapper;
using TODO.API.Data.Interfaces;
using TODO.API.Dtos;
using TODO.API.Dtos.Params;
using TODO.API.Models;
using TODO.API.Models.Helpers;

namespace TODO.API.Manager
{
    public class NotesManager
    {
        private readonly INotesRepository _NotesRepository;
        private readonly ITodoRepository _TodoRepository;
        private readonly IMapper _Mapper;
        public NotesManager(INotesRepository notesRepository, ITodoRepository todoRepository, IMapper mapper)
        {
            this._Mapper = mapper;
            this._TodoRepository = todoRepository;
            this._NotesRepository = notesRepository;
        }
        public NotesManager()
        {
            
        }

        public async Task<PagedList<NoteDto>> GetNotes(NotesParam noteParam)
        {
            var NotesFromRepo = await _NotesRepository.GetNotes(noteParam);

            var NotesToReturn = PagedList<NotesHeader>.ToMappedPagedList<NotesHeader, NoteDto>(NotesFromRepo, _Mapper);
            //  _Mapper.Map<PagedList<NoteDto>>(NotesFromRepo);

            return NotesToReturn;
        }

        public async Task<NoteDto> AddNote(NoteDto noteToAdd)
        {
            //TODO validation

            var _noteToInsert = _Mapper.Map<NotesHeader>(noteToAdd);
            _TodoRepository.Add(_noteToInsert);

            var _result = await _TodoRepository.SaveAll();

            var _noteToReturn = _Mapper.Map<NoteDto>(_noteToInsert);
            return _noteToReturn;
        }


        public bool ValidateNote(NoteDto noteDto)
        {
            bool isValid = true;

            

            return isValid;
        }
    }
}