using Microsoft.EntityFrameworkCore;

namespace WeedingPlanner.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
    }
}
