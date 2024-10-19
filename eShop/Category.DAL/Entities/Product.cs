using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public string? Season { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Summary { get; set; }
        public string? ImageSrc { get; set; }
        [Required]
        public decimal WholesalePrice { get; set; }
        [Required]
        public decimal RetailPrice { get; set; }
        [Required]
        public int Count { get; set; }
        public int FreeCount { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
