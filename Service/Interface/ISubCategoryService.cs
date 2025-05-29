using OnlineStore.Model.Dto.SubCategory;

namespace OnlineStore.Service
{
    public interface ISubCategoryService
    {
        public Task<ICollection<SubCategoryDto>> GetAll();
        public Task<SubCategoryDto?> GetById(Guid id);
        public Task<bool> Create(SubCategoryDto SubCategoryDto);  // Changed return type
        public Task<bool> Update(SubCategoryDto SubCategoryDto, Guid id);  // Changed return type
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id);
    }
}