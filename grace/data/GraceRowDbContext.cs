using Microsoft.EntityFrameworkCore;

namespace grace.data
{
    internal class GraceRowDbContext : DbContext
    {
        public DbSet<Grace> Graces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Globals.GetInstance().ConnectionString;
            optionsBuilder.UseSqlite(connectionString); // Replace with your SQLite database file path
        }
    }
}
