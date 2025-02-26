using ToDoListCodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.User_.Commands;

namespace ToDoListCodeFirst.CQRS.User_.Handlers
{
    public class DeleteUserHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserCommand command)
        {
            var user = await _context.Users.FindAsync(command.Id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}