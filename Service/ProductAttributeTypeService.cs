using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Model;
using OnlineStore.Model.Dto.ProductAttributeType;

namespace OnlineStore.Service
{
    public class ProductAttributeTypeService : IProductAttributeTypeService
    {
        private readonly AppDbContext _context;

        public ProductAttributeTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ProductAttributeTypeDto>> GetAll()
        {
            return await _context.productAttributeTypes
                    .Select(s => new ProductAttributeTypeDto
                    {
                        ProuctAttributeTypeName = s.ProductAttributeTypeName
                    })
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<ProductAttributeTypeDto?> GetById(Guid id)
        {
            return await _context.productAttributeTypes
                    .Where(c => c.ProductAttributeTypeId == id)
                    .Select(s => new ProductAttributeTypeDto
                    {
                        ProuctAttributeTypeName = s.ProductAttributeTypeName
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        public async Task<ProductAttributeTypeDto> Create(ProductAttributeTypeDto productAttributeTypeDto)
        {
            var productAttributeType = new ProductAttributeType
            {
                ProductAttributeTypeName = productAttributeTypeDto.ProuctAttributeTypeName,
            };

            _context.productAttributeTypes.Add(productAttributeType);
            await _context.SaveChangesAsync();
            return productAttributeTypeDto;
        }

        public async Task<ProductAttributeTypeDto> Update(ProductAttributeTypeDto productAttributeTypeDto, Guid id)
        {
            var productAttributeType = new ProductAttributeType
            {
                ProductAttributeTypeId = id,
                ProductAttributeTypeName = productAttributeTypeDto.ProuctAttributeTypeName
            };

            _context.productAttributeTypes.Update(productAttributeType);
            await _context.SaveChangesAsync();
            return productAttributeTypeDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var productAttributeType = await _context.productAttributeTypes.FindAsync(id);
            if (productAttributeType == null)
            {
                return false;
            }

            productAttributeType.isDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Restore(Guid id)
        {
            var productAttributeType = await _context.productAttributeTypes.FindAsync(id);
            if (productAttributeType == null)
            {
                return false;
            }

            productAttributeType.isDeleted = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var productAttributeType = await _context.productAttributeTypes.FindAsync(id);
            if (productAttributeType == null)
            {
                return false;
            }

            _context.productAttributeTypes.Remove(productAttributeType);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddOn(Guid productAttributeTypeId, Guid subcategoryId)
        {
            var productAttribute = await _context.productAttributeTypes
                                    .Include(s => s.subCategories)
                                    .FirstOrDefaultAsync();
            var subCategory = await _context.SubCategories.FindAsync(subcategoryId);
            if (productAttribute != null && subCategory != null)
            {
                productAttribute.subCategories!.Add(subCategory);
                return true;
            }
            return false;
        }

        public async Task<bool> TakeOut(Guid productAttributeTypeId, Guid subcategoryId)
        {
            var productAttribute = await _context.productAttributeTypes
                                    .Include(s => s.subCategories)
                                    .FirstOrDefaultAsync();
            var subCategory = await _context.SubCategories.FindAsync(subcategoryId);
            if (productAttribute != null && subCategory != null)
            {
                productAttribute.subCategories!.Remove(subCategory);
                return true;
            }
            return false;
        }
    }
}