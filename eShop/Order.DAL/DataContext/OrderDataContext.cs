using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.DataContext
{
    public class OrderDataContext : DbContext
    {
        public virtual DbSet<Order.DAL.Entities.Order> Orders { get; set; }
        public virtual DbSet<Order.DAL.Entities.OrderItem> OrderItems { get; set; }

        public OrderDataContext(DbContextOptions<OrderDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order.DAL.Entities.Order>().HasData(
                new Entities.Order { Id = 1, OrderTime = DateTime.Now, UserId = 1 },
                new Entities.Order { Id = 2, OrderTime = DateTime.Now, UserId = 2 },
                new Entities.Order { Id = 3, OrderTime = DateTime.Now, UserId = 2 },
                new Entities.Order { Id = 4, OrderTime = DateTime.Now, UserId = 3 },
                new Entities.Order { Id = 5, OrderTime = DateTime.Now, UserId = 3 }
            );

            modelBuilder.Entity<Order.DAL.Entities.OrderItem>().HasData(
                new Entities.OrderItem { Id = 1, ProductId = 1, Quantity = 10, OrderId = 1 },
                new Entities.OrderItem { Id = 2, ProductId = 1, Quantity = 10, OrderId = 2 },
                new Entities.OrderItem { Id = 3, ProductId = 1, Quantity = 10, OrderId = 3 },
                new Entities.OrderItem { Id = 4, ProductId = 1, Quantity = 10, OrderId = 4 },
                new Entities.OrderItem { Id = 5, ProductId = 1, Quantity = 10, OrderId = 4 }
            );
        }
    }
}
