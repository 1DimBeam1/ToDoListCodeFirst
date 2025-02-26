using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.To_Do.Queries;

namespace ToDoListCodeFirst.CQRS.To_Do.Handlers
{
    public class GetAllToDosHandler : IQueryHandler<GetAllToDosQuery, IEnumerable<ToDo>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllToDosHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDo>> Handle(GetAllToDosQuery query)
        {
            return await _context.Tasks.ToListAsync();
        }
    }
}