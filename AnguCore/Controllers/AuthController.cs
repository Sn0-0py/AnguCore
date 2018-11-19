using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AnguCore.Infrastructure.Data.Identity;
using AnguCore.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AnguCore.Controllers
{

    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;

        public AuthController(
            UserManager<ApplicationIdentityUser> userManager,
            SignInManager<ApplicationIdentityUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET api/values
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            if (ModelState.IsValid)
            {
                //var user = await _userManager.FindByEmailAsync(model.Email);

                //if (user == null)
                //    return NotFound(model);

                //var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok(new { token = GenerateToken() });
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationIdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false );
                }
                return Ok(new { Token = GenerateToken() });

            }
            return BadRequest(ModelState);
        }

        private string GenerateToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://angucore.azurewebsites.net/",
                audience: "http://angucore.azurewebsites.net/",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}