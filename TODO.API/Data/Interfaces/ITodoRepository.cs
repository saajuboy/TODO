namespace TODO.API.Data.Interfaces
{
    public interface ITodoRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}