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

        public async Task<bool> DeleteNoteDetail(int noteDetailid)
        {
            var _noteToDelete = await _NotesRepository.GetNoteDetail(noteDetailid);

            if (_noteToDelete != null)
            {
                _TodoRepository.Delete(_noteToDelete);
            }

            if (await _TodoRepository.SaveAll())
                return true;

            return false;

        }

        public async Task<NoteDto> CreateNote(NoteDto noteDto)
        {
            if (!ValidateNote(noteDto))
            {
                return null;
            }

            var noteToCreate = _Mapper.Map<NotesHeader>(noteDto);
            _TodoRepository.Add(noteToCreate);

            if (await _TodoRepository.SaveAll())
            {
                var noteDtoToReturn = _Mapper.Map<NoteDto>(noteToCreate);
                return noteDtoToReturn;
            }

            return null;
        }
        public async Task<NoteDetailDto> CreateNoteDetail(NoteDetailDto noteDetailDto)
        {

            var noteDetailToCreate = _Mapper.Map<NotesDetail>(noteDetailDto);
            var notesParam = new NotesParam();
            notesParam.NotesId = noteDetailToCreate.NotesHeaderId;
            var NoteHeaders = await _NotesRepository.GetNotes(notesParam);

            if (NoteHeaders != null && NoteHeaders.Count() > 0)
            {
                noteDetailToCreate.NotesHeader = NoteHeaders[0];

                _TodoRepository.Add(noteDetailToCreate);

                if (await _TodoRepository.SaveAll())
                {
                    var noteDtoToReturn = _Mapper.Map<NoteDetailDto>(noteDetailToCreate);
                    return noteDtoToReturn;
                }

            }
            return null;
        }

        public bool ValidateNote(NoteDto noteDto)
        {
            bool isValid = true;



            return isValid;
        }
    }
}