using Microsoft.AspNetCore.Mvc;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;


namespace ToDoListCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ToDoListController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<ToDoList> Get()
        {
            return _context.ToDoList.AsEnumerable();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<ToDoList>> GetToDoList(int id)
        {
            var list = await _context.ToDoList.FindAsync(id);

            if (list == null)
            {
                return NotFound();
            }
            return list;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ToDoList>> PostToDoList(ToDoList list)
        {
            _context.ToDoList.Add(list);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetToDoList), new { id = list.listID }, list);
        }
    }
}
