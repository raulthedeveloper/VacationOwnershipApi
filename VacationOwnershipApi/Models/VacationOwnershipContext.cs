using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VacationOwnershipApi.Models
{
    public partial class VacationOwnershipContext : DbContext
    {
        public VacationOwnershipContext()
        {
        }

        public VacationOwnershipContext(DbContextOptions<VacationOwnershipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Resort> Resort { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=VacationOwnership;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.EmployeeId);

                entity.HasIndex(e => e.UnitId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UnitId);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasIndex(e => e.ResortId);

                entity.Property(e => e.Purchased)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Resort)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.ResortId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
