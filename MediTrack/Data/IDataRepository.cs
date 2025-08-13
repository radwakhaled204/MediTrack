namespace MediTrack.Data
{
    public interface IDataRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int? id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int? id);

    }
}
