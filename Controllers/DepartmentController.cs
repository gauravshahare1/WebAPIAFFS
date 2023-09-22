using AAFS.BAL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIAFFS.DAL.DBContext1;
using WebAPIAFFS.DAL.Enums;
using WebAPIAFFS.Helpers;
using WebAPIAFFS.Models;

namespace WebAPIAFFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDepartmentService _deptService;

        public DepartmentController(AppDbContext context, IDepartmentService deptService)
        {
            _context = context;
            _deptService = deptService;
        }

        [HttpGet("DepartmentDetails")]
        public async Task<ActionResult<DepartmentModel>> Details(Guid Id)
        {
            ServiceResponse<DepartmentModel> serviceResponse = new ServiceResponse<DepartmentModel>();



            try
            {
                DepartmentModel Projects = await _deptService.Details(Id);



                if (Projects == null)
                {
                    serviceResponse.ErrorMessage = "Departments Details Not Found For ProjectId" + ' ' + Id;
                    serviceResponse.apiResponseStatus = APIResponseStatus.Error;
                    return NotFound(serviceResponse);
                }
                else
                {
                    serviceResponse.apiResponseStatus = APIResponseStatus.Success;
                    serviceResponse.result = Projects;
                    return Ok(serviceResponse);
                }
            }
            catch
            {
                serviceResponse.apiResponseStatus = APIResponseStatus.Error;
                serviceResponse.ErrorMessage = "System Exception";
                return BadRequest(serviceResponse);
            }

        }

        [HttpPost("InsertDepartmentDetails")]
        public async Task<ActionResult<bool>> Insert_DetailsOfEmployee(DepartmentModel transaction)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();



            try
            {
                var success = await _deptService.Insert(transaction);
                serviceResponse.ErrorMessage = "Department Details Inserted Successfully";
                serviceResponse.result = success.ToString();
               
            }
            catch
            {
            
                serviceResponse.ErrorMessage = "Project Basic Details Not Inserted";
                return BadRequest(serviceResponse);
            }

            return Ok(serviceResponse);

        }

        [HttpGet("DepartmentList")]
        public ServiceResponse<IEnumerable<DepartmentModel>> ListDetails()
        {
            ServiceResponse<IEnumerable<DepartmentModel>> response = new ServiceResponse<IEnumerable<DepartmentModel>>();
            try
            {
                response = _deptService.Get();

            }
            catch (Exception ex)
            {
                 // response.ErrorMessage = ErrorMessages.Error_System_Exception;
                response.apiResponseStatus = APIResponseStatus.Error;
                //  _logger.LogError(ex, "DepartmentController [DepartmentList]: " + ex.Message);
            }

            return response;
        }

        [HttpPost("DeleteDepartmentDetails")]
        public async Task<ActionResult<bool>> Delete_ProjectBasicDetails(Guid Id, DepartmentModel transaction)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();



            try
            {
                var success = await _deptService.Delete(Id, transaction);
                serviceResponse.ErrorMessage = "Project Basic Details Deleted successfully";
                serviceResponse.result = success.ToString();
                serviceResponse.apiResponseStatus = APIResponseStatus.Success;
            }
            catch
            {
                serviceResponse.apiResponseStatus = APIResponseStatus.Error;
                serviceResponse.ErrorMessage = "System Exception";
                return BadRequest(serviceResponse);
            }

            return Ok(serviceResponse);
        }

        [HttpPut("ModifyDepartmentDetail")]
        public async Task<ActionResult<ServiceResponse<string>>> Modify(Guid Id, DepartmentModel modify)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();

            Boolean approvalStatus = false;
            try
            {
                approvalStatus = await _deptService.Modify(Id, modify);
            }
            catch
            {
                serviceResponse.apiResponseStatus = APIResponseStatus.Error;
                serviceResponse.ErrorMessage = "System Exception";
                return BadRequest(serviceResponse);
            }
            if (!approvalStatus)
            {
                serviceResponse.apiResponseStatus = APIResponseStatus.Error;
                serviceResponse.result = "Could Not Update The Department";
            }
            else
            {
                serviceResponse.apiResponseStatus = APIResponseStatus.Success;
                serviceResponse.result = "Department is Updated";
            }
            return Ok(serviceResponse);

        }


    }
}
