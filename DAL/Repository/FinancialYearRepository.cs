using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.IRepositories;
using WebAPIAFFS.DAL.DBContext1;

namespace WebAPIAFFS.DAL.Repositories
{
    public class FinancialYearRepository : Repository<FinancialYear, AppDbContext>, IFinancialYearRepository
    {
        AppDbContext _context;
        public FinancialYearRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
