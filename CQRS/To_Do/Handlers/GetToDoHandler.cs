using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.CQRS.To_Do.Queries;

namespace ToDoListCodeFirst.CQRS.To_Do.Handlers
{
    public class GetToDoHandler : IQueryHandler<GetToDoQuery, ToDo>
    {
        private readonly ApplicationDbContext _context;

        public GetToDoHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDo> Handle(GetToDoQuery query)
        {
            return await _context.Tasks.FindAsync(query.Id);
        }
    }
}