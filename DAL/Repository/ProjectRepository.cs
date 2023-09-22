using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.IRepositories;
using WebAPIAFFS.DAL.DBContext1;

namespace WebAPIAFFS.DAL.Repositories
{
    public class ProjectRepository : Repository<Project, AppDbContext>, IProjectRepository
    {
        AppDbContext _context;
        public ProjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
