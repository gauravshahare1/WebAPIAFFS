using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.IRepositories;
using WebAPIAFFS.DAL.DBContext1;

namespace WebAPIAFFS.DAL.Repositories
{
    public class ProjectNatureRepository : Repository<ProjectNature, AppDbContext>, IProjectNatureRepositroy
    {
        AppDbContext _context;
        public ProjectNatureRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
