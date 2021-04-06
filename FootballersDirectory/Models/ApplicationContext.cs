using Microsoft.EntityFrameworkCore;

namespace FootballersDirectory.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FootballerEntity> Footballers { get; set; }
        public DbSet<GenderEntity> Genders { get; set; }
        public DbSet<CommandEntity> Commands { get; set; }
    }
}
