using WebAPIAFFS.Helpers;
using WebAPIAFFS.Models;

namespace AAFS.BAL.IService
{
    public interface IDepartmentService
    {


        public Task<bool> Insert(DepartmentModel Entry);
        public Task<DepartmentModel> Details(Guid Id);
        public Task<bool> Modify(Guid Id, DepartmentModel Modify);
        public ServiceResponse<IEnumerable<DepartmentModel>> Get();
        public Task<bool> Delete(Guid Id, DepartmentModel Entry);
        public Task<ICollection<DepartmentModel>> GetAllAsync();
    }
}
