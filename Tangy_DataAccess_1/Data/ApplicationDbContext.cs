using Microsoft.EntityFrameworkCore;

namespace Tangy_DataAccess_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-M71R1CT\\SQLEXPRESS; Database=Test_Blazor;" +
                "Trusted_connection=true; TrustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
