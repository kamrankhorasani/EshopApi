using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EshopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Username or password is required");
            }

            if (login.name.ToLower() != "kamran" || login.password.ToLower() != "123")
            {
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurFirst.NetCore3RestApiForTestWithJwt"));

            var signedCretin = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);

            var tokenOption =
                new JwtSecurityToken(issuer: "http://localhost:53119",
                    claims:new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,login.name),
                        new Claim(ClaimTypes.Role,"Admin")
                    },
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signedCretin);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

            return Ok(new {token = tokenString});

        }
    }
}