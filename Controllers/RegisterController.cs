using AB_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;

namespace AB_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {


        private readonly Ab238_salesContext _context;

        public RegisterController(Ab238_salesContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
           
            var PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = PasswordHash;   
          
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        /*
        // GET: api/UsersInfo/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        */
    }
}
