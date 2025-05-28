using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using OnlineStore.Model;

namespace OnlineStore.Service
{
    public interface IProductAttributeTypeService
    {
        public Task<ICollection<ProductAttributeType>> GetAll();
        public Task<ProductAttributeType> GetById(Guid id);
        public Task<ProductAttributeType> Create(ProductAttributeType productAttributeType);
        public Task<ProductAttributeType> Update(ProductAttributeType productAttributeType, Guid id);
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id);

    }
}