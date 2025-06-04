using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OnlineStore.Controller;
using OnlineStore.Data;
using OnlineStore.Model;
using OnlineStore.Model.Dto;
using OnlineStore.Model.Dto.Category;
using OnlineStore.Model.Dto.Menu;

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

        public async Task<ICollection<CategoryMenuDto>> GetMenu()
        {
            return await _context.Categories
                    .Select(s => new CategoryMenuDto
                    {
                        categoryId = s.SubCategoryId!.ToString()!,
                        categoryName = s.CategoryName,
                        subCategory_C = s.SubCategoryId.Select(s => new SubCategoryMenuDto
                        {
                            subCategoryId = s.SubCategoryId.ToString(),
                            subCategoryName = s.SubCategoryName,
                            productATName_SC = s.ProductAttributeTypes!.Select(s => new ProductAttributeTypeMenuDto
                            {
                                productATId = s.ProductAttributeTypeId.ToString(),
                                productATName = s.ProductAttributeTypeName
                            }).ToList()
                        }).ToList()

                    })
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