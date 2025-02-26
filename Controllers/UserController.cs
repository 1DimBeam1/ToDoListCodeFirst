using Microsoft.AspNetCore.Mvc;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ToDoListCodeFirst.DTOs;
using ToDoListCodeFirst.CQRS;
using ToDoListCodeFirst.CQRS.User_.Commands;
using ToDoListCodeFirst.CQRS.User_.Queries;

namespace ToDoListCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommandHandler<CreateUserCommand, User> _createUserHandler;
        private readonly ICommandHandler<UpdateUserCommand, User> _updateUserHandler;
        private readonly ICommandHandler<DeleteUserCommand, bool> _deleteUserHandler;
        private readonly IQueryHandler<GetUserQuery, User> _getUserHandler;
        private readonly IQueryHandler<GetAllUsersQuery, IEnumerable<User>> _getAllUsersHandler;

        public UserController(ApplicationDbContext context,
            ICommandHandler<CreateUserCommand, User> createUserHandler,
            ICommandHandler<UpdateUserCommand, User> updateUserHandler,
            ICommandHandler<DeleteUserCommand, bool> deleteUserHandler,
            IQueryHandler<GetUserQuery, User> getUserHandler,
            IQueryHandler<GetAllUsersQuery, IEnumerable<User>> getAllUsersHandler)
        {
            _context = context;
            _createUserHandler = createUserHandler;
            _updateUserHandler = updateUserHandler;
            _deleteUserHandler = deleteUserHandler;
            _getUserHandler = getUserHandler;
            _getAllUsersHandler = getAllUsersHandler;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAll()
        {
            var query = new GetAllUsersQuery();
            var users = await _getAllUsersHandler.Handle(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var query = new GetUserQuery { Id = id };
            var user = await _getUserHandler.Handle(query);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<User>> PostUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new CreateUserCommand
            {
                UserName = userDTO.UserName
            };

            var user = await _createUserHandler.Handle(command);

            return CreatedAtAction(nameof(GetUser), new { id = user.userID }, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateUserCommand
            {
                Id = id,
                UserName = userDTO.UserName
            };

            var user = await _updateUserHandler.Handle(command);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            var result = await _deleteUserHandler.Handle(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}