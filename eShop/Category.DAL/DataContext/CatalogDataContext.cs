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
                new Product { Id = 1, Name = "tire 24 67 78", Summary = "tire 24 67 78", Price = 860.89m, CategoryId = 2 },
                new Product { Id = 2, Name = "tire 21 60 77", Summary = "tire 21 60 77", Price = 849.11m, CategoryId = 2 },
                new Product { Id = 3, Name = "tire 27 64 79", Summary = "tire 27 64 79", Price = 890.00m, CategoryId = 2 },
                new Product { Id = 4, Name = "AGM 26 78", Summary = "AGM 26 78", Price = 890.00m, CategoryId = 1 },
                new Product { Id = 5, Name = "AGM 66 78 98", Summary = "AGM 66 78 98", Price = 811.09m, CategoryId = 1 },
                new Product { Id = 6, Name = "AGM 11 66 77", Summary = "AGM 11 66 77", Price = 890.10m, CategoryId = 1 }
            );
        }
    }
}
