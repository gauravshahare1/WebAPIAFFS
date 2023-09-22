using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using WebAPIAFFS.DAL.DBContext1;
using WebAPIAFFS.DAL.Repositories;

namespace WebAPIAFFS.DAL.Repositories
{
    public class DistrictRepository : Repository<District, AppDbContext>, IDistrictRepository
    {
        AppDbContext _context;

        public DistrictRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}


