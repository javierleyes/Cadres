using Cadres.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Cadres.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        /*
        * 1_ Add-Migration InitialMigration
        * 2_ Update-Database
        * 
        * Drop-Database
        */

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { }

        public DbSet<Rod> Rods { get; set; }
        //public DbSet<Frame> Frames { get; set; }
        //public DbSet<Order> Orders { get; set; }
    }
}
