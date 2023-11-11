using Microsoft.EntityFrameworkCore;

namespace WeedingPlanner.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Budject> Budjects { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
    }
}
