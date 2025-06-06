using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model.Dto.Menu;

namespace OnlineStore.Model.Dto
{
    public class CategoryMenuDto
    {
        public string categoryId { get; set; } = string.Empty;
        public string categoryName { get; set; } = string.Empty;
        public List<SubCategoryMenuDto> subCategory_C { get; set; } = new List<SubCategoryMenuDto>();
    }
}