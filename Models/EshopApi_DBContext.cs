using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EshopApi.Models
{
    public partial class EshopApi_DBContext : DbContext
    {
        public EshopApi_DBContext()
        {
        }

        public EshopApi_DBContext(DbContextOptions<EshopApi_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersItems> OrdersItems { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SalesPersons> SalesPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(150);

                entity.Property(e => e.State).HasMaxLength(150);

                entity.Property(e => e.ZipCode).HasMaxLength(150);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(150);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customer");

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SalesPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_SalesPersons");
            });

            modelBuilder.Entity<OrdersItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersItems_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersItems_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.ProductsName).HasMaxLength(150);

                entity.Property(e => e.Status).HasMaxLength(150);

                entity.Property(e => e.Varienty).HasMaxLength(150);
            });

            modelBuilder.Entity<SalesPersons>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.State).HasMaxLength(150);

                entity.Property(e => e.ZipCode).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
