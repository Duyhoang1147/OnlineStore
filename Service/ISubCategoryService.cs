using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model;

namespace OnlineStore.Service
{
    public interface ISubCategoryService
    {
        public Task<ICollection<SubCategory>> GetAll();
        public Task<SubCategory> GetById(Guid id);
        public Task<SubCategory> Create(SubCategory subCategory);
        public Task<SubCategory> Update(SubCategory subCategory, Guid id);
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id);
    }
}