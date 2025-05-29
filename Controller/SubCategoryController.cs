using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Model.Dto.SubCategory;
using OnlineStore.Service;

namespace OnlineStore.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _service;

        public SubCategoryController(ISubCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subCategory = await _service.GetAll();
            return Ok(subCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subCategory = await _service.GetById(id);
            return Ok(subCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryDto subCategoryDto)
        {
            var subCategory = await _service.Create(subCategoryDto);
            if (subCategory == false)
            {
                return BadRequest("Creare SubCategory fails");
            }
            return Ok("Create success");
        }

        [HttpPut]
        public async Task<IActionResult> Update(SubCategoryDto subCategoryDto, Guid id)
        {
            var subCategory = await _service.Update(subCategoryDto, id);
            if (subCategory == false)
            {
                return BadRequest("Update subCategory fails");
            }
            return Ok("Update success");
        }

        [HttpPut]
        public async Task<IActionResult> Delete(Guid id)
        {
            var subCategory = await _service.Delete(id);
            if (subCategory == false)
            {
                return BadRequest("Delete fails");
            }
            return Ok("Delete successs");
        }

        [HttpPut]
        public async Task<IActionResult> Restore(Guid id)
        {
            var subCategory = await _service.Restore(id);
            if (subCategory == false)
            {
                return BadRequest("Restore fails");
            }
            return Ok("Restore success");
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var subCategory = await _service.Remove(id);
            if (subCategory == false)
            {
                return BadRequest("Remove fails");
            }
            return Ok("Remove success");
        }
    }
}