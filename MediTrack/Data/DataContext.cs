using Microsoft.EntityFrameworkCore;
using MediTrack.Models;
namespace MediTrack.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
    }

}
