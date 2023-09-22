using WebAPIAFFS.DAL.Enums;

namespace WebAPIAFFS.Helpers
{
    public class ServiceResponse<T> 
    {
        public T? result { get; set; }          
        public APIResponseStatus apiResponseStatus { get; set; }
        public string? ErrorMessage { get; set; }
    }

    
}
