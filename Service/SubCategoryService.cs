using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Model;
using OnlineStore.Model.Dto.SubCategory;

namespace OnlineStore.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly AppDbContext _context;

        public SubCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<SubCategoryDto>> GetAll()
        {
            return await _context.SubCategories
                    .Include(i => i.category)
                    .Select(s => new SubCategoryDto
                    {
                        SubCategoryId = s.SubCategoryId,
                        SubCategoryName = s.SubCategoryName,
                        categoryId  = s.categoryId,
                        categoryName = s.category!.CategoryName,
                    })
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<SubCategoryDto?> GetById(Guid id)
        {
            return await _context.SubCategories
                    .Include(i => i.category)
                    .Where(c => c.SubCategoryId == id)
                    .Select(s => new SubCategoryDto
                    {
                        SubCategoryId = s.SubCategoryId,
                        SubCategoryName = s.SubCategoryName,
                        categoryId  = s.categoryId,
                        categoryName = s.category!.CategoryName,
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Create(SubCategoryDto subCategoryDto)
        {
            try
            {
                var category_subCategory = await _context.Categories.FindAsync(subCategoryDto.categoryId);
                if (category_subCategory == null)
                {
                    return false;
                }

                var subCategory = new SubCategory
                {
                    SubCategoryName = subCategoryDto.SubCategoryName,
                    categoryId = subCategoryDto.categoryId,
                };

                _context.SubCategories.Add(subCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(SubCategoryDto subCategoryDto, Guid id)
        {
            try
            {
                var category_subCategory = await _context.Categories.FindAsync(subCategoryDto.categoryId);
                if (category_subCategory == null)
                {
                    return false;
                }

                var subCategory = new SubCategory
                {
                    SubCategoryId = id,
                    SubCategoryName = subCategoryDto.SubCategoryName,
                    categoryId = subCategoryDto.categoryId,
                };

                _context.SubCategories.Update(subCategory);
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
            var subcategory = await _context.SubCategories.FindAsync(id);
            if (subcategory == null)
            {
                return false;
            }

            subcategory.isDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Restore(Guid id)
        {
            var subcategory = await _context.SubCategories.FindAsync(id);
            if (subcategory == null)
            {
                return false;
            }

            subcategory.isDeleted = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return false;
            }

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}