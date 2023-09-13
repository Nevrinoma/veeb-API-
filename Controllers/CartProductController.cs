using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using orm.Data;
using veeb.Models;

namespace veeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<CartProduct> GetCartProducts()
        {
            var cartProduct = _context.CartProducts.ToList();
            return cartProduct;
        }

        [HttpPost]
        public List<CartProduct> PostCartProduct([FromBody] CartProduct cart)
        {
            _context.CartProducts.Add(cart);
            _context.SaveChanges();
            return _context.CartProducts.ToList();
        }

        [HttpDelete("{id}")]
        public List<CartProduct> DeleteCartProduct(int id)
        {
            var cart = _context.CartProducts.Find(id);

            if (cart == null)
            {
                return _context.CartProducts.ToList();
            }

            _context.CartProducts.Remove(cart);
            _context.SaveChanges();
            return _context.CartProducts.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CartProduct> GetCartProduct(int id)
        {
            var cart = _context.CartProducts.Find(id);

            if (cart == null)
            {
                return NotFound();
            }


            return cart;
        }

        [HttpPut("{id}")]
        public ActionResult<List<CartProduct>> PutCartProduct(int id, [FromBody] CartProduct updatedCartProduct)
        {
            var cart = _context.CartProducts.Find(id);

            if (cart == null)
            {
                return NotFound();
            }

            cart.ProductId = updatedCartProduct.ProductId;
            cart.Quantity = updatedCartProduct.Quantity;

            _context.CartProducts.Update(cart);
            _context.SaveChanges();

            return Ok(_context.CartProducts);
        }
    }
}
