namespace ToDoListCodeFirst.CQRS.To_DoList.Commands
{
    public class DeleteToDoListCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}