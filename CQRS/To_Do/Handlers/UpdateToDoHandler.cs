using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.To_Do.Commands;

namespace ToDoListCodeFirst.CQRS.To_Do.Handlers
{
    public class UpdateToDoHandler : ICommandHandler<UpdateToDoCommand, ToDo>
    {
        private readonly ApplicationDbContext _context;

        public UpdateToDoHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDo> Handle(UpdateToDoCommand command)
        {
            var task = await _context.Tasks.FindAsync(command.Id);

            if (task == null)
            {
                return null; // Или выбросить исключение
            }

            task.taskName = command.taskName;
            task.taskDescription = command.taskDescription;
            task.taskStatus = command.taskStatus;

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return task;
        }
    }
}