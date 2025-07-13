using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] // No auth needed to get token
    public class AuthController : ControllerBase
    {
        private string GenerateJSONWebToken(int userId, string userRole)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecretkey1234567890!!"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Role, userRole),         // 👈 This is the key line
        new Claim("UserId", userId.ToString())
    };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(2), // Set expiration to 2 minutes
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetToken()
        {
            var token = GenerateJSONWebToken(1, "Admin"); // or use "POC" to test restriction
            return Ok(new { token });
        }
    }
}
