using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.IRepositories;
using WebAPIAFFS.DAL.DBContext1;

namespace WebAPIAFFS.DAL.Repositories
{
    public class ProjectTypeRepository : Repository<ProjectType, AppDbContext>, IProjectTypeRepository
    {
        AppDbContext _context;
        public ProjectTypeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
