using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class Product
    {
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("subCategory")]
        public Guid SubCategoryId { get; set; }
        public required SubCategory subCategory { get; set; }
        public ICollection<ProductAttribute> productAttributes { get; set; } = new List<ProductAttribute>();
    }
}