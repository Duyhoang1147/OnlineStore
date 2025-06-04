using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Model;
using OnlineStore.Model.Dto.Product;
using OnlineStore.Model.Dto.ProductAttribute;

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
                        ProductId = s.ProductId,
                        ProductName = s.ProductName,
                        Description = s.Description,
                        Price = s.Price,
                        Quantity = s.Quantity,
                        CategoryId = s.subCategory!.categoryId,
                        categoryName = s.subCategory.category!.CategoryName,
                        SubCategoryId = s.SubCategoryId,
                        SubCategoryName = s.subCategory!.SubCategoryName,
                        productAttributeDtos = s.productAttributes.Select(s => new ProductAttributeDto
                        {
                            ProductAttributeId = s.ProductAttributeId,
                            value = s.value,
                            ProductAttributeTypeId = s.ProductAttributeTypeId,
                            ProductAttributeTypeName = s.productAttributeType!.ProductAttributeTypeName
                        }).ToList()
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
                        ProductId = s.ProductId,
                        ProductName = s.ProductName,
                        Description = s.Description,
                        Price = s.Price,
                        Quantity = s.Quantity,
                        CategoryId = s.subCategory!.categoryId,
                        categoryName = s.subCategory.category!.CategoryName,
                        SubCategoryId = s.SubCategoryId,
                        SubCategoryName = s.subCategory!.SubCategoryName,
                        productAttributeDtos = s.productAttributes.Select(s => new ProductAttributeDto
                        {
                            ProductAttributeId = s.ProductAttributeId,
                            value = s.value,
                            ProductAttributeTypeId = s.ProductAttributeTypeId,
                            ProductAttributeTypeName = s.productAttributeType!.ProductAttributeTypeName
                        }).ToList()
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        public async Task<ProductDto> Create(ProductDto productDto)
        {
            var subCategory = await _context.SubCategories
                            .Include(i => i.ProductAttributeTypes)
                            .FirstOrDefaultAsync(s => s.SubCategoryId == productDto.SubCategoryId);
            if (subCategory == null)
            {
                throw new Exception("SubCategory Not Found");
            }

            var validAttributeTypeIds = subCategory.ProductAttributeTypes!
                                      .Select(pat => pat.ProductAttributeTypeId)
                                        .ToList();


            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                SubCategoryId = productDto.SubCategoryId,
            };

            foreach (var productAT in productDto.productAttributeDtos)
            {
                if (!validAttributeTypeIds.Contains(productAT.ProductAttributeTypeId))
                {
                    throw new Exception("productAttributeType is not validate in subCategory");
                }

                var productAttribute = new ProductAttribute
                {
                    value = productAT.value,
                    ProductId = product.ProductId,
                    ProductAttributeTypeId = productAT.ProductAttributeTypeId
                };

                _context.productAttributes.Add(productAttribute);
            }
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return productDto;
        }

        public async Task<ProductDto> Update(ProductDto productDto, Guid id)
        {
            var product = await _context.products
                .Include(p => p.productAttributes)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                throw new Exception($"Product with ID {id} not found");
            }

            product.ProductName = productDto.ProductName;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Quantity = productDto.Quantity;

            foreach (var attrDto in productDto.productAttributeDtos)
            {
                var existingAttribute = product.productAttributes
                    .FirstOrDefault(pa => pa.ProductAttributeTypeId == attrDto.ProductAttributeTypeId);

                if (existingAttribute != null)
                {
                    existingAttribute.value = attrDto.value;
                }
                else
                {
                    throw new Exception($"ProductAttribute with TypeID {attrDto.ProductAttributeTypeId} not found for Product");
                }
            }

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