using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Controller.AdminController
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            var roles = _roleManager.Roles.Select(c => new
            {
                c.Id,
                c.Name
            })
            .AsNoTracking()
            .ToList();

            return Task.FromResult<IActionResult>(Ok(roles));
        }
    }
}