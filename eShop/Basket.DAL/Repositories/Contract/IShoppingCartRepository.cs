using Basket.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DAL.Repositories.Contract
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart?> GetShoppingCart(string userName);
        Task<ShoppingCart?> UpdateShoppingCart(ShoppingCart cart);
        Task DeleteShoppingCart(string userName);
    }
}
