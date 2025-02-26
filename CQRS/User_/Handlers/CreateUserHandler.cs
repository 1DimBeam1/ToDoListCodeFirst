using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.CQRS.User_.Commands;

namespace ToDoListCodeFirst.CQRS.User_.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand, User>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(CreateUserCommand command)
        {
            var user = new User
            {
                UserName = command.UserName
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}