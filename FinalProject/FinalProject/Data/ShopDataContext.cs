﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //định nghĩa cho từng entity
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(c => new { c.CategoryId });
                e.Property(c => c.CategoryName).IsRequired().HasMaxLength(150);
                e.HasIndex(c => c.CategoryName).IsUnique(true);
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(p => p.ProductId);

                e.Property(p => p.ProductName).IsRequired();

                e.Property(p => p.Price).HasDefaultValue(0);

                e.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .HasConstraintName("FK_Product_Category")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ProductPrice>(e => {
                e.ToTable("ProductPrice");
                e.HasKey(pp => new { pp.ProductId, pp.SizeId, pp.ColorId});

                e.HasOne(pp => pp.Product)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(pp => pp.ProductId);

                e.HasOne(pp => pp.Size)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(pp => pp.SizeId);

                e.HasOne(pp => pp.Color)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(pp => pp.ColorId);
            });
        }
    }
}
