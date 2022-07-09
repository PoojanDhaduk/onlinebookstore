using BookStore.models.Models;
using BookStore.models.ViewModels;

namespace BookStore.Repository
{
    public class RoleRepository : BaseRepository
    {
        testContext _context = new testContext();

        public ListResponse<Role> GetRoles()
        {
            var query = _context.Roles.AsQueryable();
            var totalRecords = query.Count();
            IEnumerable<Role> role = query;
            return new ListResponse<Role>()
            {
                Results = role,
                TotalRecords = totalRecords
            };
        }

    }
}