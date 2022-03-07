using TODO.API.Dtos.Params;
using TODO.API.Models;
using TODO.API.Models.Helpers;

namespace TODO.API.Data.Interfaces
{
    public interface INotesRepository
    {
         Task<PagedList<NotesHeader>> GetNotes(NotesParam notesParam);
    }
}