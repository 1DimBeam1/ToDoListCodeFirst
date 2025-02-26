using ToDoListCodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.To_DoList.Commands;

namespace ToDoListCodeFirst.CQRS.To_DoList.Handlers
{
    public class DeleteToDoListHandler : ICommandHandler<DeleteToDoListCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteToDoListHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteToDoListCommand command)
        {
            var list = await _context.ToDoList.FindAsync(command.Id);

            if (list == null)
            {
                return false;
            }

            _context.ToDoList.Remove(list);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}