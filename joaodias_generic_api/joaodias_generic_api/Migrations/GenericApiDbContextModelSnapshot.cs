﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using joaodias_generic_api.Data;

#nullable disable

namespace joaodiasgenericapi.Migrations
{
    [DbContext(typeof(GenericApiDbContext))]
    partial class GenericApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("joaodias_generic_api.Data.Entities.Coins", b =>
                {
                    b.Property<int>("CoinsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("CoinName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Variation")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("CoinsId");

                    b.ToTable("Coins");
                });
#pragma warning restore 612, 618
        }
    }
}
