using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model.Dto.Menu
{
    public class SubCategoryMenuDto
    {
        public string subCategoryId { get; set; } = string.Empty;
        public string subCategoryName { get; set; } = string.Empty;
        public List<ProductAttributeTypeMenuDto> productATName_SC { get; set; } = new List<ProductAttributeTypeMenuDto>();
    }
}