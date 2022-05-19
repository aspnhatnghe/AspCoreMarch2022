using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EStoreAPI.Data;
using EStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly eStore20Context _context;
        private readonly IConfiguration _config;

        public UserController(eStore20Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult HandleLoginAndProvideToken(LoginVM model)
        {
            var user = _context.KhachHang.SingleOrDefault(kh => kh.MaKh == model.Username && kh.MatKhau == model.Password);
            if (user == null)
            {
                return Ok(new
                {
                    Success = false,
                    Message = "Invalid username or password"
                });
            }

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_config["AppSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.HoTen),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("ID", user.MaKh),

                    //roles
                    new Claim(ClaimTypes.Role, "Admin")
                }),

                Expires = DateTime.UtcNow.AddMinutes(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                Success = true,
                Message = "Login is success",
                Token = jwtTokenHandler.WriteToken(token)
            });
        }

        // api/user
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var data = _context.KhachHang.ToList();
            return Ok(data);
        }

        // api/user
        [HttpGet("{id}")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetById(string id)
        {
            try
            {
                var data = _context.KhachHang.SingleOrDefault(kh => kh.MaKh == id);
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}