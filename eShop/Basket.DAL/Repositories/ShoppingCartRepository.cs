using Basket.DAL.Entities;
using Basket.DAL.Repositories.Contract;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.DAL.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IDistributedCache _redisCache;

        public ShoppingCartRepository(IDistributedCache cache)
        {
            _redisCache = cache;
        }

        public async Task<ShoppingCart?> GetShoppingCart(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }
        public async Task DeleteShoppingCart(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
        public async Task<ShoppingCart?> UpdateShoppingCart(ShoppingCart cart)
        {
            await _redisCache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
            return await GetShoppingCart(cart.UserName);
        }
    }
}
