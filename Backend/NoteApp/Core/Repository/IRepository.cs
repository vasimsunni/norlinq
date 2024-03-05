namespace NoteApp.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> GetAsync(Guid id);
        T Get(Guid id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
