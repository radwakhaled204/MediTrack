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
    }
   
}
