using System;
using Microsoft.EntityFrameworkCore;

namespace Order.Data
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
