namespace TODO.API.Dtos.Params
{
    public class NotesParam
    {
        public int PageNumber { get; set; } = 1;
        private int _DefaultPageSize { get; set; } = 100;
        private int _PageSize;
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = (value > 0) ? value : _DefaultPageSize; }
        }

        public int NotesId { get; set; }
        public DateTime Date { get; set; }

        public string SearchString { get; set; } =string.Empty;
        public bool isArchived { get; set; } 

        public string OrderBy { get; set; } =string.Empty;
    }
}