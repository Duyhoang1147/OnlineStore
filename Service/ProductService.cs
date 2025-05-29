using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Model;
using OnlineStore.Model.Dto.Product;

namespace OnlineStore.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ProductDto>> GetAll()
        {
            return await _context.products
                    .Select(s => new ProductDto
                    {
                        ProductName = s.ProductName,
                        Description = s.Description,
                        Price = s.Price,
                        Quantity = s.Quantity,
                        categoryName = s.subCategory != null && s.subCategory.category != null ? s.subCategory.category.CategoryName : "No Data",
                        SubCategoryName = s.subCategory != null ? s.subCategory.SubCategoryName : null,
                        ProductAttributeName = s.productAttributes.Select(pa => pa.productAttributeType!.ProductAttributeTypeName).ToList(),
                    })
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<ProductDto?> GetById(Guid id)
        {
            return await _context.products
                    .Where(c => c.ProductId == id)
                    .Select(s => new ProductDto
                    {
                        ProductName = s.ProductName,
                        Description = s.Description,
                        Price = s.Price,
                        Quantity = s.Quantity,
                        categoryName = s.subCategory != null && s.subCategory.category != null ? s.subCategory.category.CategoryName : "No Data",
                        SubCategoryName = s.subCategory != null ? s.subCategory.SubCategoryName : null,
                        ProductAttributeName = s.productAttributes.Select(pa => pa.productAttributeType!.ProductAttributeTypeName).ToList(),
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        public async Task<ProductDto> Create(ProductDto productDto)
        {
            var productAttribute = _context.productAttributes
                                .Where(c => productDto.ProductAttributeId.Contains(c.ProductAttributeId))
                                .ToList();
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                SubCategoryId = productDto.SubCategoryId,
                productAttributes = productAttribute
            };

            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return productDto;
        }

        public async Task<ProductDto> Update(ProductDto productDto, Guid id)
        {
            var productAttribute = _context.productAttributes
                                .Where(c => productDto.ProductAttributeId.Contains(c.ProductAttributeId))
                                .ToList();
            var product = new Product
            {
                ProductId = id,
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                SubCategoryId = productDto.SubCategoryId,
                productAttributes = productAttribute
            };

            _context.products.Update(product);
            await _context.SaveChangesAsync();
            return productDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            product.isDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Restore(Guid id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            product.isDeleted = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}