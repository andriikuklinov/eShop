namespace Discount.API.Models
{
    public class CouponModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
