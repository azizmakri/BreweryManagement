﻿// <auto-generated />
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231227211102_nullable-Variables")]
    partial class nullableVariables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.ApplicationCore.Entities.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BeerId"), 1L, 1);

                    b.Property<float>("AlcoholContent")
                        .HasColumnType("real");

                    b.Property<int>("BreweryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("BeerId");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Brewery", b =>
                {
                    b.Property<int>("BreweryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BreweryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BreweryId");

                    b.ToTable("Breweries");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Sale", b =>
                {
                    b.Property<int>("BeerFK")
                        .HasColumnType("int");

                    b.Property<int>("WholesalerFK")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("BeerFK", "WholesalerFK", "SaleId");

                    b.HasIndex("WholesalerFK");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Stock", b =>
                {
                    b.Property<int>("WholesalerFK")
                        .HasColumnType("int");

                    b.Property<int>("BeerFK")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("WholesalerFK", "BeerFK", "StockId");

                    b.HasIndex("BeerFK");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Wholesaler", b =>
                {
                    b.Property<int>("WholesalerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WholesalerId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WholesalerId");

                    b.ToTable("Wholesalers");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Beer", b =>
                {
                    b.HasOne("App.ApplicationCore.Entities.Brewery", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewery");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Sale", b =>
                {
                    b.HasOne("App.ApplicationCore.Entities.Beer", "Beer")
                        .WithMany("Sales")
                        .HasForeignKey("BeerFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ApplicationCore.Entities.Wholesaler", "Wholesaler")
                        .WithMany("Sales")
                        .HasForeignKey("WholesalerFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Stock", b =>
                {
                    b.HasOne("App.ApplicationCore.Entities.Beer", "Beer")
                        .WithMany("Stocks")
                        .HasForeignKey("BeerFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ApplicationCore.Entities.Wholesaler", "Wholesaler")
                        .WithMany("Stocks")
                        .HasForeignKey("WholesalerFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Beer", b =>
                {
                    b.Navigation("Sales");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Brewery", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("App.ApplicationCore.Entities.Wholesaler", b =>
                {
                    b.Navigation("Sales");

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
