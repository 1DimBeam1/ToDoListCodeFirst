using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.User_.Commands
{
    public class UpdateUserCommand : ICommand<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}