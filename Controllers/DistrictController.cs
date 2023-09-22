using AAFS.BAL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIAFFS.BAL.IServices;
using WebAPIAFFS.DAL.DBContext1;
using WebAPIAFFS.DAL.Enums;
using WebAPIAFFS.Helpers;
using WebAPIAFFS.Models;

namespace WebAPIAFFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDistrictService _service;

        public DistrictController(AppDbContext context, IDistrictService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet("DistrictDetails")]
        public async Task<ActionResult<DistrictModel>> Details(Guid Id)
        {
            ServiceResponse<DistrictModel> serviceResponse = new ServiceResponse<DistrictModel>();



            try
            {
                DistrictModel Projects = await _service.Details(Id);



                if (Projects == null)
                {
                    serviceResponse.ErrorMessage = "District Details Not Found For ProjectId" + ' ' + Id;
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

        [HttpPost("InsertDistrictDetails")]
        public async Task<ActionResult<bool>> Insert(DistrictModel transaction)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();



            try
            {
                var success = await _service.Insert(transaction);
                serviceResponse.ErrorMessage = "District Details Inserted Successfully";
                serviceResponse.result = success.ToString();

            }
            catch
            {

                serviceResponse.ErrorMessage = "District Details Not Inserted";
                return BadRequest(serviceResponse);
            }

            return Ok(serviceResponse);

        }

        [HttpGet("DistrictList")]
        public ServiceResponse<IEnumerable<DistrictModel>> ListDetails()
        {
            ServiceResponse<IEnumerable<DistrictModel>> response = new ServiceResponse<IEnumerable<DistrictModel>>();
            try
            {
                response = _service.Get();

            }
            catch (Exception ex)
            {
                // response.ErrorMessage = ErrorMessages.Error_System_Exception;
                response.apiResponseStatus = APIResponseStatus.Error;
                
            }

            return response;
        }

        [HttpPost("DeleteDistrictDetails")]
        public async Task<ActionResult<bool>> Delete(Guid Id, DistrictModel transaction)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();



            try
            {
                var success = await _service.Delete(Id, transaction);
                serviceResponse.ErrorMessage = "District Details Deleted successfully";
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

        [HttpPut("ModifyDistrictDetail")]
        public async Task<ActionResult<ServiceResponse<string>>> Modify(Guid Id, DistrictModel modify)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();

            Boolean approvalStatus = false;
            try
            {
                approvalStatus = await _service.Modify(Id, modify);
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
                serviceResponse.result = "Could Not Update The District";
            }
            else
            {
                serviceResponse.apiResponseStatus = APIResponseStatus.Success;
                serviceResponse.result = "District0 is Updated";
            }
            return Ok(serviceResponse);

        }

    }
}
