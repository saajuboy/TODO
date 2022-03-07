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
            var users = _context.NotesHeaders
           .Include(p => p.NotesDetails)
           .OrderByDescending(u => u.Date)
           .AsQueryable();


            return await PagedList<NotesHeader>.CreateAsync(users, notesParam.PageNumber, notesParam.PageSize);
        }
    }
}