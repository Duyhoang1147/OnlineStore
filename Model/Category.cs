using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class Category
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        public string CategoryName { get; set; } = string.Empty;
        public bool isDeleted { get; set; } =  false;


        public ICollection<SubCategory>? SubCategoryId { get; set; }
    }
}