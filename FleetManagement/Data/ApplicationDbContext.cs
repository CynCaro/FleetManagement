using Microsoft.EntityFrameworkCore;

namespace FleetManagement
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Taxi> Taxis { get; set; }
    }
}
