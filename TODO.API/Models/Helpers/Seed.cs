using TODO.API.Data;

namespace TODO.API.Models.Helpers
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedData(){
            if (!_context.NotesHeaders.Any())
            {
                SeedNotes();
            }
        }
        
        private void SeedNotes()
        {
            IList<NotesHeader> defaultNotes = new List<NotesHeader>();
            IList<NotesDetail> defaultNoteDetails1 = new List<NotesDetail>();
            IList<NotesDetail> defaultNoteDetails2 = new List<NotesDetail>();
            IList<NotesDetail> defaultNoteDetails3 = new List<NotesDetail>();

            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 1_1", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.Assigned });
            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 1_2", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.Active });
            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 1_3", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.OnHold });
            
            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 2_1", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.Assigned });
            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 2_2", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.Active });
            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 2_3", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.OnHold });
            
            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 3_1", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.Assigned });
            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 3_2", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.Active });
            defaultNoteDetails1.Add(new NotesDetail { Title = "Test title 3_3", Description = "sadhaskhd asdads asdads", Archived = false, Status = Common.Enums.NoteState.OnHold });

            defaultNotes.Add(new NotesHeader() { Description = "test Desc 1", Date = new DateTime(), NotesDetails = new List<NotesDetail>(defaultNoteDetails1) });
            defaultNotes.Add(new NotesHeader() { Description = "test Desc 2", Date = new DateTime(), NotesDetails = new List<NotesDetail>(defaultNoteDetails2) });
            defaultNotes.Add(new NotesHeader() { Description = "test Desc 3", Date = new DateTime(), NotesDetails = new List<NotesDetail>(defaultNoteDetails3) });

            _context.NotesHeaders.AddRange(defaultNotes);
            _context.SaveChanges();
        }
    }
}