using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Model.Dto.UserDto;

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

        public async Task<IActionResult> Create([FromBody] RoleDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existRole = await _roleManager.RoleExistsAsync(model.RoleName);
            if (existRole)
            {
                return BadRequest("role has exist");
            }

            var role = await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
            if (role.Succeeded)
            {
                return Ok(role);
            }
            return BadRequest("Create fail");
        }

        public async Task<IActionResult> Update([FromBody] RoleDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role == null)
            {
                return BadRequest("role is not exist");
            }

            role.Name = model.RoleName;
            role.NormalizedName = model.RoleName.ToUpper();

            var updateRole = await _roleManager.UpdateAsync(role);
            if (updateRole.Succeeded)
            {
                return Ok("update successful");
            }
            return BadRequest("Update fail");
        }

        public async Task<IActionResult> Delete([FromBody] RoleDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role == null)
            {
                return BadRequest("role is not exist");
            }

            var roleResult = await _roleManager.DeleteAsync(role);
            if (roleResult.Succeeded)
            {
                return Ok("Delete successful");
            }
            return BadRequest("Delete fail");
        }

        public async Task<IActionResult> AddClaim([FromBody] RoleClaimDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role == null)
            {
                return BadRequest("role is not exist");
            }

            var claim = await _roleManager.AddClaimAsync(role, new Claim(model.ClaimType, model.ClaimValue));
            if (claim.Succeeded)
            {
                return Ok("Add claim successful");
            }

            return BadRequest("Add Claims fail");
        }

        public async Task<IActionResult> DeleteClaim([FromBody] RoleClaimDto model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role == null)
            {
                return BadRequest("role not found");
            }

            var claim = await _roleManager.RemoveClaimAsync(role, new Claim(model.ClaimType, model.ClaimValue));
            if (claim.Succeeded)
            {
                return Ok("Remove Claim successful");
            }
            
            return BadRequest("Remove fails");
        }
    }
}