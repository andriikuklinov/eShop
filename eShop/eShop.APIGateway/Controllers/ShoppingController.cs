using eShop.Aggregator.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.APIGateway.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public ShoppingController(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        [HttpGet]
        public async Task<IActionResult<ShoppingModel>> GetShopping(string userName)
        {
            var basket = await _basketService.GetShoppingCart(userName);

            foreach (var basketItem in basket.Items)
            {
                var product = (await _catalogService.GetProducts($"{{\"data\":[{{\"PropertyName\":\"Id\",\"Value\":\"{basketItem.ProductId}\"}}")).FirstOrDefault();

                if(product != null)
                {
                    basketItem.ProductName = product.Name;
                }
            }
        }
    }
}
