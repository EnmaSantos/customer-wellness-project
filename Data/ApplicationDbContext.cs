using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using customer_wellness_project.Models;

namespace customer_wellness_project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // These DbSets represent the actual tables in SQL Server
        public DbSet<Product> Products { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
