using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Model;
using OnlineStore.Model.Dto.ProductAttribute;

namespace OnlineStore.Service
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly AppDbContext _context;

        public ProductAttributeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductAttributeDto> Create(ProductAttributeDto productAttributeDto)
        {
            var product = await _context.products.FindAsync(productAttributeDto.ProductAttributeId);
            var productAttributeType = await _context.productAttributeTypes.FindAsync(productAttributeDto.ProductAttributeTypeId);
            if (product == null && productAttributeType == null)
            {
                throw new Exception("product or ProductAttribute Not Found");
            }

            var productAttribute = new ProductAttribute
            {
                value = productAttributeDto.value,
                ProductAttributeTypeId = productAttributeDto.ProductAttributeTypeId,
                productAttributeType = productAttributeType!,
                ProductId = productAttributeDto.ProductId,
                product = product!
            };

            _context.productAttributes.Add(productAttribute);
            await _context.SaveChangesAsync();
            return productAttributeDto;
        }

        public async Task<ProductAttributeDto> Update(ProductAttributeDto productAttributeDto, Guid id)
        {
            var product = await _context.products.FindAsync(productAttributeDto.ProductAttributeId);
            var productAttributeType = await _context.productAttributeTypes.FindAsync(productAttributeDto.ProductAttributeTypeId);
            if (product == null && productAttributeType == null)
            {
                throw new Exception("product or ProductAttribute Not Found");
            }

            var productAttribute = new ProductAttribute
            {
                ProductAttributeId = id,
                value = productAttributeDto.value,
                ProductAttributeTypeId = productAttributeDto.ProductAttributeTypeId,
                productAttributeType = productAttributeType!,
                ProductId = productAttributeDto.ProductId,
                product = product!
            };

            _context.productAttributes.Update(productAttribute);
            await _context.SaveChangesAsync();
            return productAttributeDto;
        }

        public async Task<bool> Remove(Guid id)
        {
            var productAttribute = await _context.productAttributes.FindAsync(id);
            if (productAttribute == null)
            {
                return false;
            }

            _context.productAttributes.Remove(productAttribute);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}