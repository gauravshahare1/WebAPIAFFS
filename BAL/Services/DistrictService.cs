using AutoMapper;
using WebAPIAFFS.BAL.IServices;
using WebAPIAFFS.DAL.DBContext1;
using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.Enums;
using WebAPIAFFS.DAL.IRepositories;
using WebAPIAFFS.Helpers;
using WebAPIAFFS.Models;

namespace WebAPIAFFS.BAL.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _iRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public DistrictService(IDistrictRepository iRepository, IMapper mapper, AppDbContext context)
        {
            _context = context;
            _iRepository = iRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid Id, DistrictModel Entry)
        {
            //insert in Department Details
            var existingData = await _iRepository.GetSingleAysnc(a => a.Id == Id);



            if (existingData != null)
            {

                _mapper.Map(Entry, existingData);



                _iRepository.Update(existingData);
                _iRepository.SaveChangesManaged();
            }
            return true;
        }

        public async Task<ICollection<DistrictModel>> GetAllAsync()
        {
            return (ICollection<DistrictModel>)_mapper.Map<DistrictModel>(_iRepository.GetAllAsync());
        }

        public async Task<DistrictModel> Details(Guid Id)
        {
            return _mapper.Map<DistrictModel>(await _iRepository.GetSingleAysnc(t => t.Id == Id));
        }

        public ServiceResponse<IEnumerable<DistrictModel>> Get()
        {
            ServiceResponse<IEnumerable<DistrictModel>> responseData = new ServiceResponse<IEnumerable<DistrictModel>>();
            try
            {
                List<District> projects = null;
                projects = _iRepository.GetAll().ToList<District>();


                responseData.result = _mapper.Map<List<District>, List<DistrictModel>>(projects);
                responseData.apiResponseStatus = APIResponseStatus.Success;


            }
            catch (Exception ex)
            {
                responseData.apiResponseStatus = APIResponseStatus.Error;

            }

            return responseData;
        }

        public async Task<bool> Insert(DistrictModel Entry)
        {
            District data = _mapper.Map<District>(Entry);


            _iRepository.Add(data);
            _iRepository.SaveChangesManaged();
            return true;
        }

        public async Task<bool> Modify(Guid Id, DistrictModel Modify)
        {
            var existingData = await _iRepository.GetSingleAysnc(a => a.Id == Id);



            if (existingData != null)
            {

                _mapper.Map(Modify, existingData);

                _iRepository.Update(existingData);
                _iRepository.SaveChangesManaged();
            }
            return true;
        }
    }
}
