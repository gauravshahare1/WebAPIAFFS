

namespace WebAPIAFFS.Models
{
    public class SiteModel
    {

        public Guid Id { get; set; }


        public Guid? DistrictId { get; set; }


        public Guid? ProjectId { get; set; }

     
        public DateTime? CreatedAt { get; set; }

      
        public DateTime? UpdatedAt { get; set; }

      
        public virtual DistrictModel? District { get; set; }

      
        public virtual ProjectModel? Project { get; set; }
    }
}
