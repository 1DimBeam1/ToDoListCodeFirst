using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.User_.Queries
{
    public class GetUserQuery : IQuery<User>
    {
        public int Id { get; set; }
    }
}