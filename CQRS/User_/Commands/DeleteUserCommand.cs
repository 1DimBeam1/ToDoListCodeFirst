namespace ToDoListCodeFirst.CQRS.User_.Commands
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}