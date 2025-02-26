using ToDoListCodeFirst.Model;

namespace ToDoListCodeFirst.CQRS.To_Do.Queries
{
    public class GetToDoQuery : IQuery<ToDo>
    {
        public int Id { get; set; }
    }
}