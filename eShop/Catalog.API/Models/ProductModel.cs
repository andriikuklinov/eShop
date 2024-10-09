namespace Catalog.API.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string? ImageSrc { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
