using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OnlineStore.Data;
using OnlineStore.Model;
using OnlineStore.Model.Dto.Category;

namespace OnlineStore.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<CategoryDto>> GetAll()
        {
            return await _context.Categories
                    .Where(c => c.isDeleted == false)
                    .Select(s => new CategoryDto
                    {
                        CategoryId = s.CategoryId,
                        CategoryName = s.CategoryName
                    })
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<CategoryDto?> GetById(Guid id)
        {
            return await _context.Categories
                    .Where(c => c.CategoryId == id)
                    .Select(s => new CategoryDto
                    {
                        CategoryId = s.CategoryId,
                        CategoryName = s.CategoryName
                    })
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Create(CategoryDto categoryDto)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = categoryDto.CategoryName
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(CategoryDto categoryDto, Guid id)
        {
            try
            {
                var category = new Category
                {
                    CategoryId = id,
                    CategoryName = categoryDto.CategoryName
                };

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            category.isDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Restore(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            category.isDeleted = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}