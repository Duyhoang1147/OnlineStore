using OnlineStore.Model;

namespace OnlineStore.Model.Dto.SubCategory
{
    public class SubCategoryDto
    {
        public Guid SubCategoryId { get; set; }
        public required string SubCategoryName { get; set; }
        public Guid categoryId { get; set; }
        public string? categoryName { get; set; } = string.Empty;
    }
}