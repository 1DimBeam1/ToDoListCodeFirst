using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.User_.Commands;

namespace ToDoListCodeFirst.CQRS.User_.Handlers
{
    public class UpdateUserHandler : ICommandHandler<UpdateUserCommand, User>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(UpdateUserCommand command)
        {
            var user = await _context.Users.FindAsync(command.Id);

            if (user == null)
            {
                return null; // Или выбросить исключение
            }

            user.UserName = command.UserName;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }
    }
}