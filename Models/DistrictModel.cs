

namespace WebAPIAFFS.Models
{
    public class DistrictModel
    {
    
        public Guid Id { get; set; }

       
        public string? Name { get; set; }

  
        public string? RefCode { get; set; }

   
        public DateTime? CreatedAt { get; set; }


        public DateTime? UpdatedAt { get; set; }

    
        //public virtual ICollection<SiteModel> Sites { get; set; } = new List<SiteModel>();
    }
}
