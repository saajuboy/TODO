namespace TODO.API.Dtos.Params
{
    public class NotesParam
    {
        public int PageNumber { get; set; } = 1;
        private int _DefaultPageSize { get; set; }
        private int _PageSize;
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = (value > 0) ? value : _PageSize; }
        }

        public int NotesId { get; set; }
        public DateTime Date { get; set; }

        public string SearchString { get; set; } = default!;
        public bool isArchived { get; set; } 

        public string OrderBy { get; set; } = default!;
    }
}