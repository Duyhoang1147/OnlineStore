using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model;

namespace OnlineStore.Service
{
    public interface ICategoryService
    {
        public Task<ICollection<Category>> Get();
        public Task<Category> GetById(Guid id);
        public Task<Category> Create(Category category);
        public Task<bool> Update(Guid id);
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id);
    }
}