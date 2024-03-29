﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Onion_Repository;

#nullable disable

namespace Onion_Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220824152321_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Onion_Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Onion_Domain.ProductDetails", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockAvailable")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("Onion_Domain.ProductDetails", b =>
                {
                    b.HasOne("Onion_Domain.Product", "Product")
                        .WithOne("ProductDetails")
                        .HasForeignKey("Onion_Domain.ProductDetails", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Onion_Domain.Product", b =>
                {
                    b.Navigation("ProductDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
