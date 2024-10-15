using eShop.Aggregator.Contracts;
using eShop.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<BasketModel> GetShoppingCart(string userName)
        {
            var response = await _httpClient.GetAsync($"/api/ShoppingCart/GetShoppingCart?userName={userName}");
            return await response.Content.ReadFromJsonAsync<BasketModel>();
        }
    }
}
