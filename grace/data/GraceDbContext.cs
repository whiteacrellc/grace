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
using grace.data.models;
using Microsoft.EntityFrameworkCore;


namespace grace.data
{

    public class GraceDbContext : DbContext
    {
        public virtual DbSet<Grace> Graces { get; set; }
        public virtual DbSet<CollectionName> Collections { get; set; }
        public virtual DbSet<Total> Totals { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pulled> PulledDb { get; set; }
        public virtual DbSet<Prefs> PrefsDb { get; set; }

        public virtual DbSet<Inventory> InventoryDb { get; set; }

        public virtual DbSet<Arrangement> Arrangement { get; set; }
        public virtual DbSet<ArrangementTotal> ArrangementTotals { get; set; }

        public static string ConnectionString { get; set; }

        public GraceDbContext(DbContextOptions<GraceDbContext> options)
            : base(options)
        {
            GraceDbContext.ConnectionString ??= DataBase.ConnectionString;
        }

        public GraceDbContext()
        {
            GraceDbContext.ConnectionString ??= DataBase.ConnectionString;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grace>(entity =>
            {
                entity.ToTable("Graces");
                // Primary key
                entity.HasKey(e => e.ID);

                entity.HasIndex(e => e.Sku).IsUnique();

                // Properties
                entity.Property(e => e.Sku)
                    .IsRequired();

                entity.Property(e => e.Brand)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired();

                entity.Property(e => e.Note)
                    .HasDefaultValue("");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                // Primary key
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Username)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired();

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

                entity.Property(e => e.LastUpdated)
                   .IsRequired();

                entity.HasOne(e => e.Grace)
                  .WithMany()
                  .HasForeignKey(e => e.GraceId)
                  .OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.User)
                   .HasDefaultValue("");

                // Performance indexes for common queries
                entity.HasIndex(e => e.GraceId);
                entity.HasIndex(e => e.LastUpdated);
                entity.HasIndex(e => new { e.GraceId, e.LastUpdated });
            });

            modelBuilder.Entity<CollectionName>(entity =>
            {
                entity.ToTable("Collections");
                // Primary key
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Name)
                .IsRequired();

                entity.HasOne(e => e.Grace)
                  .WithMany()
                  .HasForeignKey(e => e.GraceId)
                  .OnDelete(DeleteBehavior.Cascade);

                // Performance indexes for common queries
                entity.HasIndex(e => e.GraceId);
                entity.HasIndex(e => e.Name);
                entity.HasIndex(e => new { e.GraceId, e.Name });
            });

            modelBuilder.Entity<Pulled>(entity =>
            {
                // Table mapping
                entity.ToTable("PulledDb");

                // Primary key
                entity.HasKey(e => e.ID);

                entity.Property(e => e.CurrentTotal)
                  .IsRequired();

                entity.Property(e => e.CheckedInAmount)
                    .HasDefaultValue(0);

                // Relationships
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Grace)
                    .WithMany()
                    .HasForeignKey(e => e.GraceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Collection)
                    .WithMany()
                    .HasForeignKey(e => e.CollectionId); // Choose the appropriate delete behavior

                // Performance indexes for common queries
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.GraceId);
                entity.HasIndex(e => e.IsCompleted);
                entity.HasIndex(e => new { e.UserId, e.IsCompleted });
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                // Primary key
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Grace)
                 .WithMany()
                 .HasForeignKey(e => e.GraceId)
                 .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Arrangement>(entity =>
            {
                entity.ToTable("Arrangement");
                // Primary key
                entity.HasKey(e => e.ID);

                entity.HasIndex(e => new { e.Name, e.CollectionName }).IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.CollectionName)
                    .IsRequired();

                entity.Property(e => e.IsDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ArrangementTotal>(entity =>
            {
                entity.ToTable("ArrangementTotals");
                // Primary key
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CurrentTotal)
                   .IsRequired();
                entity.Property(e => e.User)
                    .IsRequired();
                entity.Property(e => e.LastUpdated)
                   .IsRequired();

                entity.HasOne(e => e.Arrangement)
                  .WithMany()
                  .HasForeignKey(e => e.ArrangementId)
                  .OnDelete(DeleteBehavior.Cascade);

                // Performance indexes for common queries
                entity.HasIndex(e => e.ArrangementId);
                entity.HasIndex(e => new { e.ArrangementId, e.LastUpdated });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
#endif
        }
    }

}
