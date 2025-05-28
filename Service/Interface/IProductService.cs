using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model;

namespace OnlineStore.Service
{
    public interface IProductService
    {
        public Task<ICollection<Product>> GetAll();
        public Task<Product> GetById(Guid id);
        public Task<Product> Create(Product product);
        public Task<Product> Update(Guid id, Product product);
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id); 

    }
}