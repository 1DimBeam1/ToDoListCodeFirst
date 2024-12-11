using Microsoft.AspNetCore.Mvc;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.Data;


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
        public IEnumerable<ToDoList> Get()
        {
            return _context.ToDoList.AsEnumerable();
        }

        [HttpGet("{id}")]
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
        public async Task<ActionResult<ToDoList>> PostToDoList(ToDoList list)
        {
            _context.ToDoList.Add(list);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetToDoList), new { id = list.listID }, list);
        }
    }
}
