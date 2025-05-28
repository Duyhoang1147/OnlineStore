using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class ProductAttributeType
    {
        [Key]
        public Guid ProductAttributeTypeId { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string ProductAttributeTypeName { get; set; } = string.Empty;
        public bool isDeleted { get; set; } =  false;

        public ICollection<ProductAttribute>? productAttributes { get; set; } = new List<ProductAttribute>();
        public ICollection<SubCategory>? subCategories { get; set; } = new List<SubCategory>();
    }
}