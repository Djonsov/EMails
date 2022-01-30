using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Email> emails { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }
    }
}
