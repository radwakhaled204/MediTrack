using Microsoft.EntityFrameworkCore;

namespace MediTrack.Data
{
    public class DataRepository<T>:IDataRepository<T> where T : class
    {
        private readonly DataContext _db;
        private readonly DbSet<T> table;
        public DataRepository(DataContext db)
        {
            _db = db;
            table = _db.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return  await table.ToListAsync();
        }
        public async Task<T> GetById(int? id)
        {
           var result = await table.FindAsync(id);
            if (result == null)
            {
                throw new KeyNotFoundException($"Cannot Found This Id {id}");
            }
                return result;
        }

    }
   
}
