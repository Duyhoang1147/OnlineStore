using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(10000, float.MaxValue, ErrorMessage = "Giá trị bắt buộc lớn hơn 10000")]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool isDeleted { get; set; } =  false;

        [Required]
        [ForeignKey("subCategory")]
        public Guid SubCategoryId { get; set; }
        public SubCategory? subCategory { get; set; }
        public ICollection<ProductAttribute> productAttributes { get; set; } = new List<ProductAttribute>();
    }
}