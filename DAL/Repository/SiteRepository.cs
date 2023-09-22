using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.IRepositories;
using WebAPIAFFS.DAL.DBContext1;

namespace WebAPIAFFS.DAL.Repositories
{
    public class SiteRepository : Repository<Site, AppDbContext>, ISiteRepository
    {
        AppDbContext _context;
        public SiteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
