using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Aggregator.Models
{
    public class CatalogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string? ImageSrc { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
