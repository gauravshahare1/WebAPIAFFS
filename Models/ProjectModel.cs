using WebAPIAFFS.DAL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.Models
{
    public class ProjectModel
    {
    
        public Guid Id { get; set; }

        public char? Mode { get; set; }

        public Guid? DepartmentId { get; set; }


        public string? Name { get; set; }

   
        public Guid? ProjectNatureId { get; set; }


        public Guid? ProjectTypeId { get; set; }

     
        public string? Description { get; set; }


        public Guid? FinancialYearId { get; set; }

      
        public DateTime? CreatedAt { get; set; }


        public DateTime? UpdateAt { get; set; }

 
        public virtual Department? Department { get; set; }

      
        public virtual FinancialYear? FinancialYear { get; set; }

     
        public virtual ProjectNature? ProjectNature { get; set; }

       
        public virtual ProjectType? ProjectType { get; set; }

  
        public virtual ICollection<Site> Sites { get; set; } = new List<Site>();
    }
}
