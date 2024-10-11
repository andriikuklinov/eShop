using Basket.BLL.Services.Contract;
using Basket.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCart(string userName)
        {
            return Ok(await _shoppingCartService.GetShoppingCart(userName));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShoppingCart(ShoppingCart cart)
        {
            return Ok(await _shoppingCartService.UpdateShoppingCart(cart));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCart(string userName)
        {
            await _shoppingCartService.DeleteShoppingCart(userName);
            return Ok();
        }
    }
}
