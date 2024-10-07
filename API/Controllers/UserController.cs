using Microsoft.AspNetCore.Mvc; // Ensure you have this using directive
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers // Note: Ensure the namespace is plural
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase // Fix the inheritance
    {
        private readonly DataContext _context; // Store the context

        public UsersController(DataContext context) // Correct constructor syntax
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync(); // Use the stored context
            return Ok(users); // Return Ok response
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return Ok(user); // Return Ok response
        }
    }
}
