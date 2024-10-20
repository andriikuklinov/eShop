using AutoMapper;
using Basket.API.Models;
using Basket.BLL.DTO;
using Basket.BLL.Services.Contract;
using Basket.DAL.Entities;
using EventBus.Messages.Common.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IMapper mapper, IShoppingCartService shoppingCartService)
        {
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckoutModel basketCheckout)
        {
            await _shoppingCartService.Checkout(_mapper.Map<CheckoutDTO>(basketCheckout));
            return Ok("Done");
        }
    }
}
