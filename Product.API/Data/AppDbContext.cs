using Microsoft.EntityFrameworkCore;
using Product.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProductViewModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<ProductViewModel>()
               .HasData(
               new { ProductId = 1, Name = "GTX 1070", Category = "Hardware", Price = 2000.0, StockNumber = 1 },
               new { ProductId = 2, Name = "GT 650", Category = "Hardware", Price = 250.0 , StockNumber = 1 },
               new { ProductId = 3, Name = "Teclado", Category = "Periféricos", Price = 100.0, StockNumber = 1 },
               new { ProductId = 4, Name = "Fone", Category = "Periféricos", Price = 150.0, StockNumber = 2 },
               new { ProductId = 5, Name = "Mouse", Category = "Periféricos", Price = 50.0, StockNumber = 2 }
               );
        }
    }

   

}
