﻿namespace Order.API.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
    }
}
