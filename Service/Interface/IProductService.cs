using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model;
using OnlineStore.Model.Dto.Product;

namespace OnlineStore.Service
{
    public interface IProductService
    {
        public Task<ICollection<ProductDto>> GetAll();
        public Task<ProductDto?> GetById(Guid id);
        public Task<ProductDto> Create(ProductDto ProductDto);
        public Task<ProductDto> Update(ProductDto ProductDto, Guid id);
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id); 

    }
}