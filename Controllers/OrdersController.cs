using System.Collections.Generic;
using ApiOrderBook.Models;
using ApiOrderBook.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiOrderBook.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GettAll();
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetById(long id)
        {
            var order = _orderRepository.Find(id);
            if (order == null)
                return NotFound();

            return new ObjectResult(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            _orderRepository.Add(order);
            return CreatedAtRoute("GetOrder", new { id = order.IdOrder }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Order order)
        {
            if (order == null || order.IdOrder != id)
                return BadRequest();

            var _order = _orderRepository.Find(id);

            if (order == null)
                return NotFound();

            _order.price = order.price;

            _orderRepository.Update(_order);
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var order = _orderRepository.Find(id);

            if (order == null)
                return NotFound();

            _orderRepository.Remove(id);
            return new NoContentResult();
        }

    }
}