using Microsoft.EntityFrameworkCore;
using TODO.API.Data.Interfaces;
using TODO.API.Dtos.Params;
using TODO.API.Models;
using TODO.API.Models.Helpers;

namespace TODO.API.Data.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly DataContext _context;
        public NotesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<PagedList<NotesHeader>> GetNotes(NotesParam notesParam)
        {
            var notes = _context.NotesHeaders
           .Include(p => p.NotesDetails)
           .OrderByDescending(u => u.Date)
           .AsQueryable();

            //All filters
            if (notesParam.NotesId > 0)
                notes = notes.Where(u => u.Id == notesParam.NotesId);

            if (notesParam.Date > DateTime.MinValue)
                notes = notes.Where(u => u.Date.Date == notesParam.Date.Date);

            if (notesParam.isArchived.HasValue)
            {
                await notes.ForEachAsync(async a =>
                                {
                                    a.NotesDetails = a.NotesDetails.Where(x => x.Archived == notesParam.isArchived).ToList();
                                });

                notes = notes.Where(x => x.NotesDetails.Count > 0);
            }

            if (!string.IsNullOrWhiteSpace(notesParam.SearchString))
            {
                await notes.ForEachAsync(async a =>
                {
                    a.NotesDetails = a.NotesDetails.Where(x => x.Title.Contains(notesParam.SearchString)).ToList();
                });

                notes = notes.Where(x => x.NotesDetails.Count > 0);
            }

            if (!string.IsNullOrEmpty(notesParam.OrderBy))
            {
                switch (notesParam.OrderBy.ToLower())
                {
                    case "description":
                        notes = notes.OrderByDescending(u => u.Description);
                        break;
                    default:
                        notes = notes.OrderByDescending(u => u.Date);
                        break;
                }
            }

            return await PagedList<NotesHeader>.CreateAsync(notes, notesParam.PageNumber, notesParam.PageSize);
        }

        public async Task<NotesDetail> GetNoteDetail(int NoteDetailid)
        {
            var _noteDetailToReturn = await _context.NotesDetails.FirstOrDefaultAsync(x => x.Id == NoteDetailid) ?? new NotesDetail();

            return _noteDetailToReturn;
        }
    }
}