using Microsoft.EntityFrameworkCore;

namespace ApiOrderBook.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders {get;set;}
    }
}