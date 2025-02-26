using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.To_DoList.Commands;

namespace ToDoListCodeFirst.CQRS.To_DoList.Handlers
{
    public class UpdateToDoListHandler : ICommandHandler<UpdateToDoListCommand, ToDoList>
    {
        private readonly ApplicationDbContext _context;

        public UpdateToDoListHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoList> Handle(UpdateToDoListCommand command)
        {
            var list = await _context.ToDoList.FindAsync(command.Id);

            if (list == null)
            {
                return null; // Или выбросить исключение
            }

            list.userID = command.userID;
            list.taskID = command.taskID;

            _context.Entry(list).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return list;
        }
    }
}