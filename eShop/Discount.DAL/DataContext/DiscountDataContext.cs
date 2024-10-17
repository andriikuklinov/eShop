using Discount.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.DAL.DataContext
{
    public class DiscountDataContext : DbContext
    {
        public DiscountDataContext(DbContextOptions<DiscountDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "tire 24 67 78", DiscountPercentage = 25, Description = "test description Tire" },
                new Coupon { Id = 1, ProductName = "AGM 26 78", DiscountPercentage = 15, Description = "test description AGM" },
                new Coupon { Id = 1, ProductName = "AGM 11 66 77", DiscountPercentage = 5, Description = "test description AGM" }
            );
        }
    }
}
