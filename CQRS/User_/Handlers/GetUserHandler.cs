using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;
using ToDoListCodeFirst.CQRS.User_.Queries;

namespace ToDoListCodeFirst.CQRS.User_.Handlers
{
    public class GetUserHandler : IQueryHandler<GetUserQuery, User>
    {
        private readonly ApplicationDbContext _context;

        public GetUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserQuery query)
        {
            return await _context.Users.FindAsync(query.Id);
        }
    }
}