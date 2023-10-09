using Microsoft.EntityFrameworkCore;


namespace grace.data
{

    internal class TotalDbContext : DbContext
    {
        public DbSet<Total> Totals { get; set; }
        public DbSet<Grace> Graces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Total>()
                .HasOne(g => g.Grace)
                .WithMany()
                .HasForeignKey(g => g.GraceID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Globals.GetInstance().ConnectionString;
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
