using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.To_Do.Commands
{
    public class CreateToDoCommand : ICommand<ToDo>
    {
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public string taskStatus { get; set; }
    }
}