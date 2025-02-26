using ToDoListCodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.To_Do.Commands;

namespace ToDoListCodeFirst.CQRS.To_Do.Handlers
{
    public class DeleteToDoHandler : ICommandHandler<DeleteToDoCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteToDoHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteToDoCommand command)
        {
            var task = await _context.Tasks.FindAsync(command.Id);

            if (task == null)
            {
                return false;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}