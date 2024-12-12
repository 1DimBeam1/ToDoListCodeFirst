using Microsoft.AspNetCore.Mvc;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.Data;


namespace ToDoListCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ToDo> GetTaskAll()
        {
            return _context.Tasks.AsEnumerable();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> PostTask(ToDo task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.taskID }, task);
        }

    }
}
