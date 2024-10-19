using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DAL.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string productName { get; set; }
        public string ProductId { get; set; }
    }
}
