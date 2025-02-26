using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.To_DoList.Queries;

namespace ToDoListCodeFirst.CQRS.To_DoList.Handlers
{
    public class GetAllToDoListsHandler : IQueryHandler<GetAllToDoListsQuery, IEnumerable<ToDoList>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllToDoListsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoList>> Handle(GetAllToDoListsQuery query)
        {
            return await _context.ToDoList.ToListAsync();
        }
    }
}