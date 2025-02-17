using Microsoft.AspNetCore.Mvc;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ToDoListCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context; 
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<User> GetUsersAll()
        {
           return _context.Users.AsEnumerable();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser),new {id = user.userID}, user);
        }

    }
}
