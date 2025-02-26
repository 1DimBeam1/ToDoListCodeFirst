using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.To_DoList.Commands
{
    public class UpdateToDoListCommand : ICommand<ToDoList>
    {
        public int Id { get; set; }
        public int userID { get; set; }
        public int taskID { get; set; }
    }
}