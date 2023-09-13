using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orm.Data;
using veeb.Models;

namespace veeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public List<Order> PostOrder([FromBody] Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            _context.Orders.Include(a => a.PersonId).ToList();
            return _context.Orders.Include(a => a.CartProduct).ToList();
        }

        [HttpGet]
        public List<Order> GetOrders()
        {
            var orders = _context.Orders.Include(a => a.CartProduct).ToList();

            return orders;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _context.CartProducts.Include(a => a.PersonId).Include(a => a.CartProduct).FirstOrDefault(a => a.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpDelete("{id}")]
        public List<Order> DeleteOrder(int id)
        {
            var order = _context.Orders.Include(a => a.PersonId).Include(a => a.CartProduct).FirstOrDefault(a => a.Id == id);

            if (order == null)
            {
                return _context.Orders.Include(a => a.PersonId).ToList();
            }

            if (order.CartProduct != null)
            {
                _context.CartProducts.Remove((CartProduct)order.CartProduct);
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return _context.Orders.Include(a => order.PersonId).ToList();
        }

        [HttpPut("{id}")]
        public ActionResult<List<Order>> PutOrder(int id, [FromBody] Order updatedOrder)
        {
            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            order.TotalSum = updatedOrder.TotalSum;
            order.Paid = updatedOrder.Paid;
            order.PersonId = updatedOrder.PersonId;

            _context.Orders.Update(order);
            _context.SaveChanges();

            return Ok(_context.Orders);
        }
    }
}
