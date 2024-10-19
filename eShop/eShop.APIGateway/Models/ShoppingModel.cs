using eShop.Aggregator.Models;

namespace eShop.APIGateway.Models
{
    public class ShoppingModel
    {
        public BasketModel Basket { get; set; }
        public string UserName { get; set; }
        public IEnumerable<object> Orders { get; set; }
    }
}
