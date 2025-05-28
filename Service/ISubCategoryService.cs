using OnlineStore.Model.Dto.SubCategory;

namespace OnlineStore.Service
{
    public interface ISubCategoryService
    {
        public Task<ICollection<SubCategoryDto>> GetAll();
        public Task<SubCategoryDto?> GetById(Guid id);
        public Task<SubCategoryDto> Create(SubCategoryDto SubCategoryDto);
        public Task<SubCategoryDto> Update(SubCategoryDto SubCategoryDto, Guid id);
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id);
    }
}