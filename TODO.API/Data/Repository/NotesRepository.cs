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
                notes = notes.Where(u => u.Date == notesParam.Date);

            if (notesParam.isArchived.HasValue)
                notes = notes.Where(u => u.NotesDetails.Any(x=>x.Archived == notesParam.isArchived));

            // if (!string.IsNullOrWhiteSpace(notesParam.SearchString))
            // {
            //     notes = notes.Where(x=>x.NotesDetails.)
                
            // }

            if (!string.IsNullOrEmpty(notesParam.OrderBy))
            {
                switch (notesParam.OrderBy.ToLower())
                {
                    case "description" :
                        notes = notes.OrderByDescending(u => u.Description);
                        break;
                    default:
                        notes = notes.OrderByDescending(u => u.Date);
                        break;
                }
            }

            return await PagedList<NotesHeader>.CreateAsync(notes, notesParam.PageNumber, notesParam.PageSize);
        }
    }
}