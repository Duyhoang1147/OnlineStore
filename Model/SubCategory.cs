using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class SubCategory
    {
        public Guid SubCategoryId { get; set; } = Guid.NewGuid();
        public String SubCategoryName { get; set; } = string.Empty;

        [ForeignKey("category")]
        public Guid categoryId { get; set; }
        public required Category category { get; set; }
        public ICollection<Product>? products { get; set; }
        public ICollection<ProductAttributeType>? ProductAttributeTypes { get; set; }
    }
}