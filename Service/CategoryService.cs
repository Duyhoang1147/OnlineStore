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
                    .Select(s => new CategoryDto
                    {
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
                        CategoryName = s.CategoryName
                    })
                    .FirstOrDefaultAsync();
        }

        public async Task<CategoryDto> Create(CategoryDto categoryDto)
        {
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return categoryDto;
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto, Guid id)
        {
            var category = new Category
            {
                CategoryId = categoryDto.CategoryId,
                CategoryName = categoryDto.CategoryName
            };

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return categoryDto;
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