using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class SubCategory
    {
        [Key]
        public Guid SubCategoryId { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string SubCategoryName { get; set; } = string.Empty;
        [Required]
        public bool isDeleted { get; set; } = false;


        [ForeignKey("category")]
        public Guid categoryId { get; set; }
        public required Category category { get; set; }
        public ICollection<Product>? products { get; set; }
        public ICollection<ProductAttributeType>? ProductAttributeTypes { get; set; }
    }
}