using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) { }

        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Species { get; set; }
         public DbSet<Enclosure> Enclosures { get; set; }
    }
}