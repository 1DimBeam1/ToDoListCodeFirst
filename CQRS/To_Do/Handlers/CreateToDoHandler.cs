using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.CQRS.To_Do.Commands;

namespace ToDoListCodeFirst.CQRS.To_Do.Handlers
{
    public class CreateToDoHandler : ICommandHandler<CreateToDoCommand, ToDo>
    {
        private readonly ApplicationDbContext _context;

        public CreateToDoHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDo> Handle(CreateToDoCommand command)
        {
            var task = new ToDo
            {
                taskName = command.taskName,
                taskDescription = command.taskDescription,
                taskStatus = command.taskStatus
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }
    }
}