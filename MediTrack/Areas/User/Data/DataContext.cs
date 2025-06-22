using Microsoft.EntityFrameworkCore;

using MediTrack.Areas.User.Models;
namespace MediTrack.Areas.User.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<MediTrack.Areas.User.Models.User> users { get; set; }
    }
   
}
