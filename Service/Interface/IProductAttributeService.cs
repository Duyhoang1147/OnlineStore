using OnlineStore.Model.Dto.ProductAttribute;

namespace OnlineStore.Service
{
    public interface IProductAttributeService
    {
        public Task<ProductAttributeDto> Create(ProductAttributeDto ProductAttributeDto);
        public Task<ProductAttributeDto> Update(ProductAttributeDto ProductAttributeDto, Guid id);
        public Task<bool> Remove(Guid id);   
    }
}