using Microsoft.EntityFrameworkCore;
using MediTrack.Core.Models;
namespace MediTrack.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Insurance> insurances { get; set; }


        //connect two tables with ForeignKey
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Insurance)
                .WithOne()
                .HasForeignKey<Patient>(p => p.InsuranceId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }

}
