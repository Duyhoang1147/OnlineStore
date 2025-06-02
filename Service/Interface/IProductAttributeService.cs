using OnlineStore.Model.Dto.ProductAttribute;

namespace OnlineStore.Service
{
    public interface IProductAttributeService
    {
        public Task<ProductAttributeDto> Create(ProductAttributeDto ProductAttributeDto, Guid ProductId);
        public Task<bool> Remove(Guid id);   
    }
}