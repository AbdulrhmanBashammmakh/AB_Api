using AB_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace AB_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {


        private readonly Ab238_salesContext _context;
        public IConfiguration _configuration;

        public TokenController(IConfiguration configuration, Ab238_salesContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
         public async Task<IActionResult> CheckedUser(User ur)
        {

            if(ur != null && ur.Username !=null && ur.Password != null)
            {
                //  !BCrypt.Verify(ur.Password, user.PasswordHash)
                //  var user_check = await GetUser(ur.Username , ur.Password);
                var user_check = await CheckUserEmail(ur.Username);
                if (user_check != null || BC.Verify(ur.Password, user_check.Password))
                {
                    // return Ok(user_check);  
                    var claims = new[]
                    {
                         new Claim  (JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                         new Claim      (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                         new Claim         (JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                         new Claim        ("id",user_check.Id.ToString()),
                         new Claim        ("userName",user_check.Username)

                    //   new Claim(JwtR)
                   };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,expires:DateTime.UtcNow.AddDays(1),signingCredentials: signin);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid user Or password");
                }
            }
            else
            {
                return BadRequest();
            }

           }

        private async Task<User> GetUser(string username, string password)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(i => i.Username == username && i.Password == password);
            return user;

                }
        private async Task<User> CheckUserEmail(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName);
        }
    }
}
