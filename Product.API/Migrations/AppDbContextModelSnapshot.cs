﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.API.Data;

namespace Product.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Product.API.ViewModel.ProductViewModel", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StockNumber")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = "Hardware",
                            Name = "GTX 1070",
                            Price = 2000.0,
                            StockNumber = 1
                        },
                        new
                        {
                            ProductId = 2,
                            Category = "Hardware",
                            Name = "GT 650",
                            Price = 250.0,
                            StockNumber = 1
                        },
                        new
                        {
                            ProductId = 3,
                            Category = "Periféricos",
                            Name = "Teclado",
                            Price = 100.0,
                            StockNumber = 1
                        },
                        new
                        {
                            ProductId = 4,
                            Category = "Periféricos",
                            Name = "Fone",
                            Price = 150.0,
                            StockNumber = 2
                        },
                        new
                        {
                            ProductId = 5,
                            Category = "Periféricos",
                            Name = "Mouse",
                            Price = 50.0,
                            StockNumber = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
