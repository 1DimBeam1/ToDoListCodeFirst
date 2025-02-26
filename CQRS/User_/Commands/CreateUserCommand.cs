using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.User_.Commands
{
    public class CreateUserCommand : ICommand<User>
    {
        public string UserName { get; set; }
    }
}