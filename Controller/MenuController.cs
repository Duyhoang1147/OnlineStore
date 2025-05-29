using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Service;

namespace OnlineStore.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ICategoryService _service;
        public MenuController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            var Menu = await _service.GetMenu();
            return Ok(Menu);
        }
    }
}