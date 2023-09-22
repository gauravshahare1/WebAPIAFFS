using WebAPIAFFS.Helpers;
using WebAPIAFFS.Models;

namespace WebAPIAFFS.BAL.IServices
{
    public interface IDistrictService
    {
        public Task<bool> Insert(DistrictModel Entry);
        public Task<DistrictModel> Details(Guid Id);
        public Task<bool> Modify(Guid Id, DistrictModel Modify);
        public ServiceResponse<IEnumerable<DistrictModel>> Get();
        public Task<bool> Delete(Guid Id, DistrictModel Entry);
        public Task<ICollection<DistrictModel>> GetAllAsync();
    }
}
