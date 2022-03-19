using static TODO.API.Common.Enums;

namespace TODO.API.Models
{
    public class NotesDetail
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public NoteState Status { get; set; }
        public bool Archived { get; set; }
        public NotesHeader NotesHeader { get; set; } = default!;
        public int NotesHeaderId { get; set; }
    }
}