using Microsoft.EntityFrameworkCore;
using TODO.API.Models;

namespace TODO.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<NotesHeader> NotesHeaders { get; set; } = default!;
        public DbSet<NotesDetail> NotesDetails { get; set; } = default!;
    }
}