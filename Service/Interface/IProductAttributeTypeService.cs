using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using OnlineStore.Model;
using OnlineStore.Model.Dto.ProductAttributeType;

namespace OnlineStore.Service
{
    public interface IProductAttributeTypeService
    {
        public Task<ICollection<ProductAttributeTypeDto>> GetAll();
        public Task<ProductAttributeTypeDto?> GetById(Guid id);
        public Task<ProductAttributeTypeDto> Create(ProductAttributeTypeDto ProductAttributeTypeDto);
        public Task<ProductAttributeTypeDto> Update(ProductAttributeTypeDto ProductAttributeTypeDto, Guid id);
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id);
        public Task<bool> AddOn(Guid productAttributeTypeId, Guid subcategoryId);
        public Task<bool> TakeOut(Guid productAttributeTypeId, Guid subcategoryId);
    }
}