using Microsoft.AspNetCore.Mvc;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ToDoListCodeFirst.DTOs;
using ToDoListCodeFirst.CQRS;
using ToDoListCodeFirst.CQRS.To_DoList.Commands;
using ToDoListCodeFirst.CQRS.To_DoList.Queries;

namespace ToDoListCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommandHandler<CreateToDoListCommand, ToDoList> _createToDoListHandler;
        private readonly ICommandHandler<UpdateToDoListCommand, ToDoList> _updateToDoListHandler;
        private readonly ICommandHandler<DeleteToDoListCommand, bool> _deleteToDoListHandler;
        private readonly IQueryHandler<GetToDoListQuery, ToDoList> _getToDoListHandler;
        private readonly IQueryHandler<GetAllToDoListsQuery, IEnumerable<ToDoList>> _getAllToDoListsHandler;

        public ToDoListController(ApplicationDbContext context,
            ICommandHandler<CreateToDoListCommand, ToDoList> createToDoListHandler,
            ICommandHandler<UpdateToDoListCommand, ToDoList> updateToDoListHandler,
            ICommandHandler<DeleteToDoListCommand, bool> deleteToDoListHandler,
            IQueryHandler<GetToDoListQuery, ToDoList> getToDoListHandler,
            IQueryHandler<GetAllToDoListsQuery, IEnumerable<ToDoList>> getAllToDoListsHandler)
        {
            _context = context;
            _createToDoListHandler = createToDoListHandler;
            _updateToDoListHandler = updateToDoListHandler;
            _deleteToDoListHandler = deleteToDoListHandler;
            _getToDoListHandler = getToDoListHandler;
            _getAllToDoListsHandler = getAllToDoListsHandler;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<IEnumerable<ToDoList>>> Get()
        {
            var query = new GetAllToDoListsQuery();
            var lists = await _getAllToDoListsHandler.Handle(query);
            return Ok(lists);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<ToDoList>> GetToDoList(int id)
        {
            var query = new GetToDoListQuery { Id = id };
            var list = await _getToDoListHandler.Handle(query);

            if (list == null)
            {
                return NotFound();
            }
            return list;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ToDoList>> PostToDoList([FromBody] ToDoListDTO listDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new CreateToDoListCommand
            {
                userID = listDTO.userID,
                taskID = listDTO.taskID
            };

            var list = await _createToDoListHandler.Handle(command);

            return CreatedAtAction(nameof(GetToDoList), new { id = list.listID }, list);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutToDoList(int id, [FromBody] ToDoListDTO listDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateToDoListCommand
            {
                Id = id,
                userID = listDTO.userID,
                taskID = listDTO.taskID
            };

            var list = await _updateToDoListHandler.Handle(command);

            if (list == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            var command = new DeleteToDoListCommand { Id = id };
            var result = await _deleteToDoListHandler.Handle(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}