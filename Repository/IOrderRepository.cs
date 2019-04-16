using System.Collections.Generic;
using ApiOrderBook.Models;

namespace ApiOrderBook.Repository
{
    public interface  IOrderRepository
    {
        void Add(Order order);
        IEnumerable<Order> GettAll();
        Order Find(long id);
        void Remove(long id);
        void Update(Order order);
    }
}