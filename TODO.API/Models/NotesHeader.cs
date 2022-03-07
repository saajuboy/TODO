namespace TODO.API.Models
{
    public class NotesHeader
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<NotesDetail> NotesDetails { get; set; } = default!;

    }
}