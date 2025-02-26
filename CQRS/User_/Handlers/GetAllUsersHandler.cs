using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using ToDoListCodeFirst.CQRS.User_.Queries;

namespace ToDoListCodeFirst.CQRS.User_.Handlers
{
    public class GetAllUsersHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUsersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
        {
            return await _context.Users.ToListAsync();
        }
    }
}