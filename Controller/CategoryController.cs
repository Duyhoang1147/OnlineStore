using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Model.Dto.Category;
using OnlineStore.Model.Dto.Product;
using OnlineStore.Service;

namespace OnlineStore.Controller
{
    /// <summary>
    /// API endpoints for managing categories
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of all categories</returns>
        /// <response code="200">Returns the list of categories</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAll();
            return Ok(categories);
        }

        /// <summary>
        /// Get a category by ID
        /// </summary>
        /// <param name="id">The ID of the category</param>
        /// <returns>The requested category</returns>
        /// <response code="200">Returns the requested category</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _service.GetById(id);
            return Ok(category);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="categoryDto">The category data</param>
        /// <returns>Result of creation operation</returns>
        /// <response code="200">Category created successfully</response>
        /// <response code="400">If the categoryDto is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("data empty");
            }
            var product = await _service.Create(categoryDto);
            if (product == false)
            {
                return BadRequest("Create fails");
            }
            return Ok("Create success!");
        }

        /// <summary>
        /// Update an existing category
        /// </summary>
        /// <param name="categoryDto">The updated category data</param>
        /// <param name="id">The ID of the category to update</param>
        /// <returns>Result of update operation</returns>
        /// <response code="200">Category updated successfully</response>
        /// <response code="400">If the categoryDto is null or ID not found</response>
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] CategoryDto categoryDto, Guid id)
        {
            if (categoryDto == null)
            {
                return BadRequest("Data Empty");
            }

            var category = await _service.Update(categoryDto, id);
            if (category == false)
            {
                return BadRequest("Id Not Found");
            }

            return Ok("Update success!");
        }

        /// <summary>
        /// Soft delete a category
        /// </summary>
        /// <param name="id">The ID of the category to delete</param>
        /// <returns>Result of delete operation</returns>
        /// <response code="200">Category deleted successfully</response>
        /// <response code="400">If the deletion fails</response>
        [HttpPut("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoryResult = await _service.Delete(id);
            if (categoryResult == false)
            {
                return BadRequest("Delete Failed");
            }
            return Ok("Delete success!");
        }

        /// <summary>
        /// Restore a soft-deleted category
        /// </summary>
        /// <param name="id">The ID of the category to restore</param>
        /// <returns>Result of restore operation</returns>
        /// <response code="200">Category restored successfully</response>
        /// <response code="400">If the restoration fails</response>
        [HttpPut("restore/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Restore(Guid id)
        {
            var categoryResult = await _service.Restore(id);
            if (categoryResult == false)
            {
                return BadRequest("Restore Failed");
            }
            return Ok("Restore success");
        }

        /// <summary>
        /// Permanently remove a category
        /// </summary>
        /// <param name="id">The ID of the category to remove</param>
        /// <returns>Result of remove operation</returns>
        /// <response code="200">Category removed successfully</response>
        /// <response code="400">If the removal fails</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(Guid id)
        {
            var categoryResult = await _service.Remove(id);
            if (categoryResult == false)
            {
                return BadRequest("Remove Failed");
            }
            return Ok("Remove success");
        }
    }
}