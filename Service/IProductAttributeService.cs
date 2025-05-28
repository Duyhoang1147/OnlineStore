using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model;

namespace OnlineStore.Service
{
    public interface IProductAttributeService
    {
        public Task<ICollection<ProductAttribute>> GetAll();
        public Task<ProductAttribute> GetById(Guid id);
        public Task<ProductAttribute> Create(ProductAttribute productAttribute);
        public Task<ProductAttribute> Update(ProductAttribute productAttribute, Guid id);
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id);   
    }
}