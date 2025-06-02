using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model.Dto.ProductAttribute
{
    public class ProductAttributeDto
    {
        public Guid ProductAttributeId { get; set; } = Guid.NewGuid();
        public string value { get; set; } = string.Empty;
        public Guid ProductAttributeTypeId { get; set; }
        public string ProductAttributeTypeName { get; set; } = string.Empty;
    }
}