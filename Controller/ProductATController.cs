using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Model.Dto.ProductAttributeType;
using OnlineStore.Service;

namespace OnlineStore.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductATController : ControllerBase
    {
        private readonly IProductAttributeTypeService _service;
        public ProductATController(IProductAttributeTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productAT = await _service.GetAll();
            return Ok(productAT);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var productAT = await _service.GetById(id);
            return Ok(productAT);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductAttributeTypeDto productAttributeTypeDto)
        {
            if (productAttributeTypeDto == null)
            {
                return BadRequest("Data Empty");
            }
            var productAT = await _service.Create(productAttributeTypeDto);
            if (productAT == false)
            {
                return BadRequest("Create fails");
            }
            return Ok("Create success");
        }

        [HttpPost("addon")]
        public async Task<IActionResult> AddOn(Guid Id_PAT, Guid Id_SC)
        {
            var addOn = await _service.AddOn(Id_PAT, Id_SC);
            if (addOn == false)
            {
                return BadRequest("Add on fails");
            }
            return Ok("Add on success");
        }

        [HttpPost("takeout")]
        public async Task<IActionResult> TakeOut(Guid Id_PAT, Guid Id_SC)
        {
            var takeOut = await _service.TakeOut(Id_PAT, Id_SC);
            if (takeOut == false)
            {
                return BadRequest("Take out fails");
            }
            return Ok("Take out success");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductAttributeTypeDto productAttributeTypeDto)
        {
            if (productAttributeTypeDto == null)
            {
                return BadRequest("Data Empty");
            }
            var productAT = await _service.Update(productAttributeTypeDto, id);
            if (productAT == false)
            {
                return BadRequest("Update fails");
            }
            return Ok("Update success");
        }

        [HttpPut("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productAT = await _service.Delete(id);
            if (productAT == false)
            {
                return BadRequest("Delete fails");
            }
            return Ok("Delete success");
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> Restore(Guid id)
        {
            var productAT = await _service.Restore(id);
            if (productAT == false)
            {
                return BadRequest("Restore fails");
            }
            return Ok("Restore success");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var productAT = await _service.Remove(id);
            if (productAT == false)
            {
                return BadRequest("Remove fails");
            }
            return Ok("Remove success");
        }
    }
}