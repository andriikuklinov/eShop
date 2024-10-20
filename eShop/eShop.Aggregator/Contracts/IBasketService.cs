using eShop.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Aggregator.Contracts
{
    public interface IBasketService
    {
        Task<BasketModel> GetShoppingCart(string userName);
    }
}
