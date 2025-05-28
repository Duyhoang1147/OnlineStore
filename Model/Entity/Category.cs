using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = string.Empty;
        public bool isDeleted { get; set; } = false;

        public ICollection<SubCategory>? SubCategoryId { get; set; }
    }
}