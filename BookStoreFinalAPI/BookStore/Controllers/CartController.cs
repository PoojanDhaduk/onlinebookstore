using Microsoft.AspNetCore.Mvc;
using BookStore.repository;
using BookStore.models.ViewModels;
using BookStore.models.Models;
namespace BookStore.Controllers
{
    [ApiController]
    [Route("Api/Cart")]
    public class CartController : Controller
    {
        CartRepository repository=new CartRepository();
        [HttpGet]
        [Route("Carts")]
        public IActionResult GetCartItems(string? keyword="")
        {
            List<Cart> cartItems = repository.GetCartItems(keyword);
            IEnumerable<CartModel> cartmodel=cartItems.Select(c=>new CartModel(c));
            return Ok(cartmodel);
        }
         [Route("{id}")]
        [HttpGet]
        public IActionResult GetCart(int id)
        {
            try
            {
                var cart = repository.GetCart(id);
                CartModel cartModel = new CartModel(cart);
                if (cart == null)
                {
                    return BadRequest("this id is not available");
                }
                return Ok(cartModel);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("add")]
        [HttpPost]

        public IActionResult AddCart(CartModel model)
        {
            if (model == null)
            {
                return BadRequest("value must be not null");
            }
            Cart cart = new Cart()
            {
                Id = model.Id,
                Userid = model.Userid,
                Bookid = model.Bookid,
                Quantity = 1
        };
            var entry = repository.AddCart(cart);
            CartModel cartModel = new CartModel(entry);
            return Ok(cartModel);
        }
        [Route("Update")]
        [HttpPut]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
            {
                return BadRequest("value must be not null");
            }
            Cart cart = new Cart()
            {
                Id = model.Id,
                Userid = model.Userid,
                Bookid = model.Bookid,
                Quantity = model.Quantity
            };
            var entry = repository.UpdateCart(cart);
            CartModel cartModel = new CartModel(entry);
            return Ok(cartModel);
        }
        [Route("Remove")]
        [HttpDelete]
        public IActionResult RemoveCart(int id)
        {
            if(id== 0)
            {
                return BadRequest("id must Be not null");
            }
            var entry = repository.RemoveCart(id);
            if(entry != null) {
                return Ok("category removed successfully");

            }
            return BadRequest("you enterd wrong id");
      
        }
    }
}
