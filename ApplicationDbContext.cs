using Microsoft.EntityFrameworkCore;
namespace Rabbit
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() { }
        public DbSet<Product> product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=EnderWarAdmin;database=firstdb;",
                new MySqlServerVersion(new Version(8, 0, 27))
            );
        }
    }
}
