﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInformation.Models
{
    public class ProductInfoContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=localhost;" +
                    "port=3306;" +
                    "user=root;" +
                    "database=mvc_practice;";

                string version = "10.4.14-MariaDB";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(entity =>
            {

                entity.Property(e => e.Name)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                   new Category()
                   {
                       ID = -1,
                       Name = "Weapons"
                   },
                   new Category()
                   {
                       ID = -2,
                       Name = "Armor"
                   },
                   new Category()
                   {
                       ID = -3,
                       Name = "Materials"
                   },
                    new Category()
                    {
                        ID = -4,
                        Name = "Consumables"
                    }
                );
            });

            modelBuilder.Entity<Product>(entity =>
            {

                entity.Property(e => e.Name)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                string keytoCategory = "FK_" + nameof(Product) + "_" + nameof(Category);

                entity.HasIndex(e => e.CategoryID)
                .HasName(keytoCategory);

                entity.HasOne(thisEntity => thisEntity.Category)
                .WithMany(parent => parent.Products)
                .HasForeignKey(thisEntity => thisEntity.CategoryID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keytoCategory);

                entity.HasData(
                   new Product()
                   {
                       ID = -1,
                       Name = "Test",
                       CategoryID = -1
                   },
                   new Product()
                   {
                       ID = -2,
                       Name = "Chocolate",
                       CategoryID = -2

                   },
                   new Product()
                   {
                       ID = -3,
                       Name = "Beskar",
                       CategoryID = -3
                   },
                    new Product()
                    {
                        ID = -4,
                        Name = "Staff of Light",
                        CategoryID = -3
                    }
               );


            });

        }
    }
}
