using System.Collections.Generic;
using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.To_Do.Queries
{
    public class GetAllToDosQuery : IQuery<IEnumerable<ToDo>>
    {
    }
}