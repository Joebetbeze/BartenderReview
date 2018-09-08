using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BartenderAppReview.Models
{
    public partial class BartendingContext : DbContext
    {
        public BartendingContext()
        {
        }

        public BartendingContext(DbContextOptions<BartendingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drink> Drink { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Bartending;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>(entity =>
            {
                entity.Property(e => e.DrinkId).HasColumnName("DrinkID");

                entity.Property(e => e.DrinkName).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerName).IsRequired();

                entity.Property(e => e.DrinkName).IsRequired();

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DrinkId);
            });
        }
    }
}
