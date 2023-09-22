using WebAPIAFFS.DAL.DBContext1;
using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.IRepositories;

namespace WebAPIAFFS.DAL.Repositories
{
    public class DepartmentRepository : Repository<Department,AppDbContext>, IDepartmentRepository
    {
        AppDbContext _context;

        public DepartmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
