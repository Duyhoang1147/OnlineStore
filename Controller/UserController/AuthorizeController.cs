using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineStore.Data;
using OnlineStore.Model.Dto.UserDto;
using OnlineStore.Model.UserEntity;

namespace OnlineStore.Controller.UserController
{
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;

        public AuthorizeController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signManager = signInManager;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                BadRequest("User not found");
            }

            var result = await _signManager.PasswordSignInAsync(user!, loginDto.Password, loginDto.RememberMe, true);
            if (result.Succeeded)
            {
                return Ok("Login successful");
            }
            return Unauthorized("Email or Password wrong");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailResult = await _userManager.FindByEmailAsync(registerDto.Email);
            if (emailResult != null)
            {
                return BadRequest("Email already in use");
            }

            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };

            var userResult = await _userManager.CreateAsync(user, registerDto.Password);
            if (userResult.Succeeded)
            {
                return Ok("Rgister successful");
            }
            return BadRequest("Server error");
        }

        public async Task<IActionResult> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                BadRequest("Not logged in");
            }
            return Ok(user);
        }
    }
}