namespace TODO.API.Dtos
{
    public class NoteDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<NoteDetailDto> NotesDetails { get; set; } = default!;
    }

    public class NoteForUpdateDto
    {
        public string Description { get; set; } = string.Empty;
    }

}