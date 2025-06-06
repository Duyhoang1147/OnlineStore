using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Model.Dto.UserDto;
using OnlineStore.Model.UserEntity;

namespace OnlineStore.Controller.UserController
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateUserInfo([FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("user not found or not Logging in");
            }

            var useranme = user.UserName;
            if (updateUserDto.Username != useranme)
            {
                var usernameResult = await _userManager.SetUserNameAsync(user, updateUserDto.Username);
                if (!usernameResult.Succeeded)
                {
                    return BadRequest("Unexpected error occurred setting useranme");
                }
            }

            await UpdateUserClaimsAsync(updateUserDto.Claims, user);
            return Ok("update successful");
        }

        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("user not found or not Logging in");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.newPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(e => e.Description));
            }
            return Ok("Change Password successful");
        }

        public async Task UpdateUserClaimsAsync(List<ClaimDto> cliamsList, User user)
        {
            var claims = await _userManager.GetClaimsAsync(user);

            foreach (var userClaims in cliamsList)
            {
                var existClaims = claims.FirstOrDefault(c => c.Type == userClaims.ClaimType);
                if (existClaims == null)
                {
                    await _userManager.AddClaimAsync(user, new Claim(userClaims.ClaimType, userClaims.ClaimValue));
                }
                else
                {
                    await _userManager.ReplaceClaimAsync(user, existClaims, new Claim(userClaims.ClaimType, userClaims.ClaimValue));
                }
            }
        }
    }
}