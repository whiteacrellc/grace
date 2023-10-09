using Microsoft.EntityFrameworkCore;


namespace grace.data
{

    public class GraceDbContext : DbContext
    {
        public DbSet<Grace> Graces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Globals.GetInstance().ConnectionString;
            optionsBuilder.UseSqlite(connectionString); // Replace with your SQLite database file path
        }
    }

}
