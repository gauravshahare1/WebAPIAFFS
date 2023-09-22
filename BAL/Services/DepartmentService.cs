using AAFS.BAL.IService;
using AutoMapper;
using WebAPIAFFS.DAL.DBContext1;
using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.DAL.Enums;
using WebAPIAFFS.DAL.IRepositories;
using WebAPIAFFS.Helpers;
using WebAPIAFFS.Models;

namespace AAFS.BAL.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _iRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public DepartmentService(IDepartmentRepository iRepository, IMapper mapper, AppDbContext context)
        {
            _context = context;
            _iRepository = iRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid Id, DepartmentModel Entry)
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

        public async Task<ICollection<DepartmentModel>> GetAllAsync()
        {
           return (ICollection<DepartmentModel>)_mapper.Map<DepartmentModel>(_iRepository.GetAllAsync());
        }

        public async Task<DepartmentModel> Details(Guid Id)
        {
            return _mapper.Map<DepartmentModel>(await _iRepository.GetSingleAysnc(t => t.Id == Id));
        }

        public ServiceResponse<IEnumerable<DepartmentModel>> Get()
        {
            ServiceResponse<IEnumerable<DepartmentModel>> responseData = new ServiceResponse<IEnumerable<DepartmentModel>>();
            try
            {
                List<Department> projects = null;
                projects = _iRepository.GetAll().ToList<Department>();


                responseData.result = _mapper.Map<List<Department>, List<DepartmentModel>>(projects);
                responseData.apiResponseStatus = APIResponseStatus.Success;


            }
            catch (Exception ex)
            {
                responseData.apiResponseStatus = APIResponseStatus.Error;
              
            }

            return responseData;
        }

        public async Task<bool> Insert(DepartmentModel Entry)
        {
            Department data = _mapper.Map<Department>(Entry);

            
            _iRepository.Add(data);
            _iRepository.SaveChangesManaged();
            return true;
        }

        public async Task<bool> Modify(Guid Id, DepartmentModel Modify)
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
