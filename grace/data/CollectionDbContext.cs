using Microsoft.EntityFrameworkCore;

/*
 * dotnet ef migrations add InitialCreate
 * dotnet ef database update
 * 
 */
namespace grace.data
{

    internal class CollectionDbContext : DbContext
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Grace> Graces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>()
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
