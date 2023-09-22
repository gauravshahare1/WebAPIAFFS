using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.DAL.Entity
{
    [Table("project_natures")]
    public class ProjectNature
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp without time zone")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("ProjectNature")]
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

        [InverseProperty("ProjectNature")]
        public virtual ICollection<ProjectType> ProjectTypes { get; set; } = new List<ProjectType>();
    }
}
