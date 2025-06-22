using Microsoft.EntityFrameworkCore;

namespace MediTrack.Areas.User.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
