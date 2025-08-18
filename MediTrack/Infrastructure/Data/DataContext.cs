using Microsoft.EntityFrameworkCore;
using MediTrack.Core.Models;
namespace MediTrack.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
    }

}
