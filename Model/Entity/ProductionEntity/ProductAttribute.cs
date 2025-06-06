using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class ProductAttribute
    {
        [Key]
        public Guid ProductAttributeId { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength]
        public string value { get; set; } = string.Empty;

        [Required]
        [ForeignKey("product")]
        public Guid ProductId { get; set; }
        public  Product? product { get; set; }
        
        [Required]
        [ForeignKey("productAttributeType")]
        public Guid ProductAttributeTypeId { get; set; }
        public ProductAttributeType? productAttributeType { get; set; }
    }
}