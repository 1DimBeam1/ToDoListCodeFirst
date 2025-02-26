using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.CQRS.To_DoList.Queries;

namespace ToDoListCodeFirst.CQRS.To_DoList.Handlers
{
    public class GetToDoListHandler : IQueryHandler<GetToDoListQuery, ToDoList>
    {
        private readonly ApplicationDbContext _context;

        public GetToDoListHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoList> Handle(GetToDoListQuery query)
        {
            return await _context.ToDoList.FindAsync(query.Id);
        }
    }
}