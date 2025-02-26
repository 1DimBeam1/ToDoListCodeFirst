using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;

using ToDoListCodeFirst.CQRS.To_DoList.Commands;

namespace ToDoListCodeFirst.CQRS.To_DoList.Handlers
{
    public class CreateToDoListHandler : ICommandHandler<CreateToDoListCommand, ToDoList>
    {
        private readonly ApplicationDbContext _context;

        public CreateToDoListHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoList> Handle(CreateToDoListCommand command)
        {
            var list = new ToDoList
            {
                userID = command.userID,
                taskID = command.taskID
            };

            _context.ToDoList.Add(list);
            await _context.SaveChangesAsync();

            return list;
        }
    }
}