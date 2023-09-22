using WebAPIAFFS.DAL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.Models
{
    public class ProjectTypeModel
    {

        public Guid Id { get; set; }


        public Guid? ProjectNatureId { get; set; }


        public string? Name { get; set; }


        public DateTime? CreatedAt { get; set; }

   
        public DateTime? UpdatedAt { get; set; }


        public virtual ProjectNature? ProjectNature { get; set; }

      
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
