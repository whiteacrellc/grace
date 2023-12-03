/*
 * Copyright (c) 2023 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 * Year: 2023
 */
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
        public DbSet<User> Users { get; set; }
        public DbSet<Pulled> PulledDb { get; set; }
        public DbSet<Prefs> PrefsDb { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static string connectionString;

        public GraceDbContext(string connectionString)
        {
            GraceDbContext.connectionString = connectionString;
        }
        public GraceDbContext()
        {
           if (GraceDbContext.connectionString == null)
            {
                GraceDbContext.connectionString = DataBase.ConnectionString;
            }
        }
#pragma warning restore CS8618 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Grace>(entity =>
            {
                entity.ToTable("Graces");
                // Primary key
                entity.HasKey(e => e.ID);

                // Properties
                entity.Property(e => e.Sku)
                    .IsRequired();

                entity.Property(e => e.Brand)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                // Primary key
                entity.HasKey(e => e.ID);

            });

            modelBuilder.Entity<Prefs>(entity =>
            {
                entity.ToTable("Prefs");
                // Primary key
                entity.HasKey(e => e.ID);

                // Properties
                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Value)
                    .IsRequired();

            });

            modelBuilder.Entity<Total>(entity =>
            {
                entity.ToTable("Totals");
                // Primary key
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Grace)
                  .WithMany()
                  .HasForeignKey(e => e.GraceId)
                  .OnDelete(DeleteBehavior.Cascade);

            });


            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("Collections");
                // Primary key
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Grace)
                  .WithMany()
                  .HasForeignKey(e => e.GraceId)
                  .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<GraceRow>(entity =>
            {
                entity.ToTable("GraceRows");
                // Primary key
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Grace)
                  .WithMany()
                  .HasForeignKey(e => e.GraceId)
                  .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Pulled>(entity =>
            {
                // Table mapping
                entity.ToTable("PulledDb");

                // Primary key
                entity.HasKey(e => e.ID);

                // Relationships
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade); // Choose the appropriate delete behavior

                entity.HasOne(e => e.Grace)
                    .WithMany()
                    .HasForeignKey(e => e.GraceId)
                    .OnDelete(DeleteBehavior.Cascade); // Choose the appropriate delete behavior

                entity.HasOne(e => e.Collection)
                    .WithMany()
                    .HasForeignKey(e => e.CollectionId)
                    .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior
            });

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString).EnableSensitiveDataLogging();
        }
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Table("Graces")]
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

        public List<Pulled> PulledDb { get; set; }
    }

    [Table("Totals")]
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

    [Table("Collections")]
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

    [Table("GraceRows")]
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

    [Table("Users")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ResetAnswer { get; set; } = string.Empty;

        public int ResetAnswerIndex { get; set; }

        public bool Admin { get; set; } = false;
 
        public bool ResetPassword { get; set; } = true;

        public List<Pulled> PulledDb { get; set; }

    }

    [Table("PulledDb")]
    public class Pulled
    {
        [Key]
        public int ID { get; set; }
        [Required]

        public string Comment { get; set; } = String.Empty;

        [Required]
        public DateTime lastUpdated { get; set; } = DateTime.Now;

        public int amount { get; set; } = 0;

        public int currentTotal { get; set; } = 0;

        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public User User { get; set; }

        public int GraceId { get; set; }
        [ForeignKey("GraceId")]

        public Grace Grace { get; set; }

        public int CollectionId { get; set; }
        [ForeignKey("CollectionId")]
        public Collection Collection { get; set; }
    }

    [Table("Prefs")]
    public class Prefs
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
