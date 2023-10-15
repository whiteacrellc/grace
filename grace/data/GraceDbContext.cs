using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grace.data
{

    public class GraceDbContext : DbContext
    {
        public DbSet<Grace> Graces { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Total> Totals { get; set; }
        public DbSet<GraceRow> GraceRows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Total>()
                .HasOne(t => t.Grace)     
                .WithMany(g => g.Totals) 
                .HasForeignKey(t => t.GraceId);

            modelBuilder.Entity<Collection>()
                .HasOne(t => t.Grace)    
                .WithMany(g => g.Collections)  
                .HasForeignKey(t => t.GraceId);

            modelBuilder.Entity<GraceRow>()
                .HasOne(t => t.Grace)
                .WithMany(g => g.GraceRows)
                .HasForeignKey(t => t.GraceId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Globals.GetInstance().ConnectionString;
            optionsBuilder.UseSqlite(connectionString); // Replace with your SQLite database file path
        }
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Grace
    {
        [Key]
        public int ID { get; set; }
        [Required]

        public string Sku { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Brand { get; set; }

        public string? Availability { get; set; }
        public string? Barcode { get; set; }


        public List<Total> Totals { get; set; }

        public List<Collection> Collections { get; set; }

        public List<GraceRow> GraceRows { get; set; }

    }


    public class Total
    {
        [Key]
        public int ID { get; set; }
        public DateTime date_field { get; set; }
        public int total { get; set; }

        // Foreign key property
        public int GraceId { get; set; }
        // Navigation property
        [ForeignKey("GraceId")]
        public Grace Grace { get; set; }

    }

    public class Collection
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        // Foreign key property
        public int GraceId { get; set; }
        // Navigation property
        [ForeignKey("GraceId")]
        public Grace Grace { get; set; }

    }

    public class GraceRow
    {
        [Key]
        public int ID { get; set; }
        [Required]

        public string Sku { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Brand { get; set; }

        public string? Availability { get; set; }
        public string? BarCode { get; set; }
        public string? Col1 { get; set; }
        public string? Col2 { get; set; }
        public string? Col3 { get; set; }
        public string? Col4 { get; set; }
        public string? Col5 { get; set; }
        public string? Col6 { get; set; }
        public int PreviousTotal { get; set; } = 0;
        public int Total { get; set; } = 0;

        public int GraceId { get; set; }
        [ForeignKey("GraceId")]
        public Grace Grace { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
