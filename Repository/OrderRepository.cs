using System.Collections.Generic;
using System.Linq;
using ApiOrderBook.Models;

namespace ApiOrderBook.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepository(OrderDbContext ctx)
        {
            _context = ctx;
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order Find(long id)
        {
            return _context.Orders.FirstOrDefault(o => o.IdOrder == id);
        }

        public IEnumerable<Order> GettAll()
        {
            return _context.Orders.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.Orders.First(o => o.IdOrder == id);
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}