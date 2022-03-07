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

            // All filters
            // users = users.Where(u => u.Id != userParams.UserId);

            // users = users.Where(u => u.Gender == userParams.Gender);

            // if (userParams.MinAge != 18 || userParams.MaxAge != 99)
            // {

            //     var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
            //     var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

            //     users = users.Where(u => (u.DateOfBirth >= minDob) && (u.DateOfBirth <= maxDob));
            // }

            // if (!string.IsNullOrEmpty(userParams.OrderBy))
            // {
            //     switch (userParams.OrderBy)
            //     {
            //         case "created":
            //             users = users.OrderByDescending(u => u.Created);
            //             break;
            //         default:
            //             users = users.OrderByDescending(u => u.LastActive);
            //             break;
            //     }
            // }

            return await PagedList<NotesHeader>.CreateAsync(users, notesParam.PageNumber, notesParam.PageSize);
        }
    }
}