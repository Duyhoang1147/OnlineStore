using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model.Dto.ProductAttribute;

namespace OnlineStore.Model.Dto.Product
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public string? categoryName { get; set; } = string.Empty;
        public Guid SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; } = string.Empty;
        public List<ProductAttributeDto> productAttributeDtos { get; set; } = new List<ProductAttributeDto>();
    }
}