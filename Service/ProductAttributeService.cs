using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ProductAttributeDto> Create([FromBody] ProductAttributeDto productAttributeDto, Guid productId)
        {

            var productAttribute = new ProductAttribute
            {
                value = productAttributeDto.value,
                ProductId = productId,
                ProductAttributeTypeId = productAttributeDto.ProductAttributeId
            };
            _context.productAttributes.Add(productAttribute);
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