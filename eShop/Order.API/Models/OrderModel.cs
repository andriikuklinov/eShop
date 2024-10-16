using Order.BLL.DTO;

namespace Order.API.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();
    }
}
