using Microsoft.EntityFrameworkCore;
using GymSmartApp.Models;

namespace GymSmartApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Trainner> Trainners { get; set; }
        public DbSet<GymMachine> GymMachines { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Local> Locals { get; set; }
    }
}
