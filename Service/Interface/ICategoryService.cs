using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model;
using OnlineStore.Model.Dto.Category;

namespace OnlineStore.Service
{
    public interface ICategoryService
    {
        public Task<ICollection<CategoryDto>> GetAll();
        public Task<CategoryDto?> GetById(Guid id);
        public Task<bool> Create(CategoryDto categoryDto);  // Changed return type
        public Task<bool> Update(CategoryDto categoryDto, Guid id);  // Changed return type
        public Task<bool> Delete(Guid id);
        public Task<bool> Restore(Guid id);
        public Task<bool> Remove(Guid id);
    }
}