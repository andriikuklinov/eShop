using Basket.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.BLL.Services.Contract
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart?> GetShoppingCart(string userName);
        Task<ShoppingCart?> UpdateShoppingCart(ShoppingCart cart);
        Task DeleteShoppingCart(string userName);
    }
}
