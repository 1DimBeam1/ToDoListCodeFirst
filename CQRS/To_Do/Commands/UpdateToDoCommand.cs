using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.To_Do.Commands
{
    public class UpdateToDoCommand : ICommand<ToDo>
    {
        public int Id { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public string taskStatus { get; set; }
    }
}