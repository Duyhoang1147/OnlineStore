using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model.Dto.ProductAttributeType
{
    public class ProductAttributeTypeDto
    {
        public Guid ProductAttributeTypeId { get; set; }
        public string ProuctAttributeTypeName { get; set; } = string.Empty;
    }
}