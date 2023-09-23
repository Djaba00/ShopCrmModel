using ShopCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.ApplicationContext
{
    public class CrmContext : DbContext
    {
        public DbSet<Check> Checks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public CrmContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Initial Catalog=ShopCrm;Integrated Security=SSPI;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(14, 2);

            modelBuilder.Entity<Check>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Checks)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Check>()
                .HasOne(c => c.Seller)
                .WithMany(c => c.Checks)
                .HasForeignKey(c => c.SellerId);

            modelBuilder.Entity<Sell>()
                .HasOne(c => c.Check)
                .WithMany(c => c.Sells)
                .HasForeignKey(c => c.CheckId);

            modelBuilder.Entity<Sell>()
                .HasOne(c => c.Product)
                .WithMany(c => c.Sells)
                .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<Check>().HasKey(c => c.CheckId);

            modelBuilder.Entity<Sell>().HasKey(c => c.SellId);

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);

            modelBuilder.Entity<Product>().HasKey(c => c.ProductId);

            modelBuilder.Entity<Seller>().HasKey(c => c.SellerId);

        }
        
    }
}
