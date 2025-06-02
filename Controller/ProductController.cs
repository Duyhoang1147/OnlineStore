using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Model;
using OnlineStore.Model.Dto.Product;
using OnlineStore.Service;

namespace OnlineStore.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetAll()
        {
            var Products = await _service.GetAll();
            return Ok(Products);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetById(id);
            return Ok(product);
        }

        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            try
            {
                var product = await _service.Create(productDto);
                if (product == null)
                {
                    return BadRequest("product not Found");
                }
                return Ok("create success");
            }
            catch
            {
                return BadRequest("create fails");
            }
        }

        public async Task<IActionResult> Update([FromBody] ProductDto productDto, Guid id)
        {
            try
            {
                var product = await _service.Update(productDto, id);
                if (product == null)
                {
                    return BadRequest("product not found");
                }
                return Ok("update success");
            }
            catch
            {
                return BadRequest("update fails");
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            if (result == false)
            {
                return BadRequest("Delete fails");
            }
            return Ok("Delete success");
        }

        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _service.Restore(id);
            if (result == false)
            {
                return BadRequest("Restore fails");
            }
            return Ok("Restore success");
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.Remove(id);
            if (result == false)
            {
                return BadRequest("Remove fails");
            }
            return Ok("Remove Success");
        }
    }
}