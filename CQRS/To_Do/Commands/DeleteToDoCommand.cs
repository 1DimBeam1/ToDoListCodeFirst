namespace ToDoListCodeFirst.CQRS.To_Do.Commands
{
    public class DeleteToDoCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}