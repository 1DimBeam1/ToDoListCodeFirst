using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.To_DoList.Queries
{
    public class GetToDoListQuery : IQuery<ToDoList>
    {
        public int Id { get; set; }
    }
}