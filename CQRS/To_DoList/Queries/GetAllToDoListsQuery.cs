using System.Collections.Generic;
using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.To_DoList.Queries
{
    public class GetAllToDoListsQuery : IQuery<IEnumerable<ToDoList>>
    {
    }
}