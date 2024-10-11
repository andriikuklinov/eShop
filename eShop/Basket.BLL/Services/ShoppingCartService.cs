using Basket.BLL.Services.Contract;
using Basket.DAL.Entities;
using Basket.DAL.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.BLL.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task DeleteShoppingCart(string userName)
        {
            await _shoppingCartRepository.DeleteShoppingCart(userName);
        }

        public async Task<ShoppingCart?> GetShoppingCart(string userName)
        {
            return await _shoppingCartRepository.GetShoppingCart(userName);
        }

        public async Task<ShoppingCart?> UpdateShoppingCart(ShoppingCart cart)
        {
            return await _shoppingCartRepository.UpdateShoppingCart(cart);
        }
    }
}
