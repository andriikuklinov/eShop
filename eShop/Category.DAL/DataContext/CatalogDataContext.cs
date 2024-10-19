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
            modelBuilder.Entity<Product>().Property(_ => _.Summary).HasMaxLength(500);
            modelBuilder.Entity<Product>().Property(_ => _.ImageSrc).HasMaxLength(30);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Brand="TOYO", Model="XCV 123x238x16", WholesalePrice=99.99m, RetailPrice=220.00m, Season="Winter", Count=10, FreeCount= 7, Code="234hgjX", Summary = "tire 24 67 78", CategoryId = 2 },
                new Product { Id = 2, Brand = "TOYO", Model="FG 12x43x56", WholesalePrice = 97.00m, RetailPrice = 210.00m, Season ="Summer", Count = 10, FreeCount = 7, Code = "234hgjX1", Summary = "tire 21 60 77", CategoryId = 2 },
                new Product { Id = 3, Brand = "TOYO", Model="HG 12x32x34", WholesalePrice = 98.9m, RetailPrice = 212.00m, Season ="Winter", Count = 10, FreeCount = 7, Code = "234hgjv2", Summary = "tire 27 64 79", CategoryId = 2 },
                new Product { Id = 4, Brand = "Bosh", Model="GF124G", WholesalePrice = 99.99m, RetailPrice = 102.00m, Count = 10, FreeCount = 7, Code = "234hg21m", Summary = "AGM 26 78", CategoryId = 1 },
                new Product { Id = 5, Brand = "Bosh", Model = "LC224X", WholesalePrice = 91.99m, RetailPrice = 99.00m, Count = 10, FreeCount = 7, Code = "67nbbb7", Summary = "AGM 66 78 98", CategoryId = 1 },
                new Product { Id = 6, Brand = "Bosh", Model = "JS994M", WholesalePrice = 92.0m, RetailPrice = 98.00m, Count = 10, FreeCount = 7, Code = "46bfhj7X", Summary = "AGM 11 66 77", CategoryId = 1 }
            );
        }
    }
}
