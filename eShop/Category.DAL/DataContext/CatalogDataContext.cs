using Catalog.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.DataContext
{
    public class CatalogDataContext: DbContext
    {
        public CatalogDataContext(DbContextOptions<CatalogDataContext> options):base(options)
        {
            
        }

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(_ => _.Name).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(_ => _.Summary).HasMaxLength(500);
            modelBuilder.Entity<Product>().Property(_ => _.ImageSrc).HasMaxLength(30);
            modelBuilder.Entity<Product>().Property(_ => _.Price).HasPrecision(18, 2);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Brand="TOYO", Model="XCV 123x238x16", WholesalePrice=99.99m, RetailPrice=220.00m, Season="Winter", Count=10, FreeCount= 7, Code="234hgjX", Name = "tire 24 67 78", Summary = "tire 24 67 78", Price = 860.89m, CategoryId = 2 },
                new Product { Id = 2, Brand = "TOYO", Model="FG 12x43x56", WholesalePrice = 97.00m, RetailPrice = 210.00m, Season ="Summer", Count = 10, FreeCount = 7, Code = "234hgjX1", Name = "tire 21 60 77", Summary = "tire 21 60 77", Price = 849.11m, CategoryId = 2 },
                new Product { Id = 3, Brand = "TOYO", Model="HG 12x32x34", WholesalePrice = 98.9m, RetailPrice = 212.00m, Season ="Winter", Count = 10, FreeCount = 7, Code = "234hgjv2", Name = "tire 27 64 79", Summary = "tire 27 64 79", Price = 890.00m, CategoryId = 2 },
                new Product { Id = 4, Brand = "Bosh", Model="GF124G", WholesalePrice = 99.99m, RetailPrice = 102.00m, Name = "AGM 26 78", Count = 10, FreeCount = 7, Code = "234hg21m", Summary = "AGM 26 78", Price = 890.00m, CategoryId = 1 },
                new Product { Id = 5, Brand = "Bosh", Model = "LC224X", WholesalePrice = 91.99m, RetailPrice = 99.00m, Name = "AGM 66 78 98", Count = 10, FreeCount = 7, Code = "67nbbb7", Summary = "AGM 66 78 98", Price = 811.09m, CategoryId = 1 },
                new Product { Id = 6, Brand = "Bosh", Model = "JS994M", WholesalePrice = 92.0m, RetailPrice = 98.00m, Name = "AGM 11 66 77", Count = 10, FreeCount = 7, Code = "46bfhj7X", Summary = "AGM 11 66 77", Price = 890.10m, CategoryId = 1 }
            );
        }
    }
}
