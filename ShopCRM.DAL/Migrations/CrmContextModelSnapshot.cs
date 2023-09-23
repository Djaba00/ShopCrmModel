﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopCRM.DAL.ApplicationContext;

#nullable disable

namespace ShopCRM.Migrations
{
    [DbContext(typeof(CrmContext))]
    partial class CrmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopCRM.DAL.Entities.Check", b =>
                {
                    b.Property<int>("CheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CheckId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("CheckId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Checks");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Sell", b =>
                {
                    b.Property<int>("SellId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SellId"));

                    b.Property<int>("CheckId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("SellId");

                    b.HasIndex("CheckId");

                    b.HasIndex("ProductId");

                    b.ToTable("Sells");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Seller", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SellerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SellerId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Check", b =>
                {
                    b.HasOne("ShopCRM.DAL.Entities.Customer", "Customer")
                        .WithMany("Checks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopCRM.DAL.Entities.Seller", "Seller")
                        .WithMany("Checks")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Sell", b =>
                {
                    b.HasOne("ShopCRM.DAL.Entities.Check", "Check")
                        .WithMany("Sells")
                        .HasForeignKey("CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopCRM.DAL.Entities.Product", "Product")
                        .WithMany("Sells")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Check");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Check", b =>
                {
                    b.Navigation("Sells");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Customer", b =>
                {
                    b.Navigation("Checks");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Product", b =>
                {
                    b.Navigation("Sells");
                });

            modelBuilder.Entity("ShopCRM.DAL.Entities.Seller", b =>
                {
                    b.Navigation("Checks");
                });
#pragma warning restore 612, 618
        }
    }
}
