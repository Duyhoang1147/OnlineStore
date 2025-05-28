using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model.Dto.Category
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public required string CategoryName { get; set; }
    }
}