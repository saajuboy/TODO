using static TODO.API.Common.Enums;

namespace TODO.API.Dtos
{
    public class NoteDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public NoteState Status { get; set; }
        public bool Archived { get; set; }
    }
}