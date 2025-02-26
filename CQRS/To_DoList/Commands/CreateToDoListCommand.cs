using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.To_DoList.Commands
{
    public class CreateToDoListCommand : ICommand<ToDoList>
    {
        public int userID { get; set; }
        public int taskID { get; set; }
    }
}