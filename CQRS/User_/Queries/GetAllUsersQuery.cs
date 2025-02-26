using System.Collections.Generic;
using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.User_.Queries
{
    public class GetAllUsersQuery : IQuery<IEnumerable<User>>
    {
    }
}