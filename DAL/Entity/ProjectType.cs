using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.DAL.Entity
{
    [Table("prroject_type")]
    public class ProjectType
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("project_nature_id")]
        public Guid? ProjectNatureId { get; set; }

        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp without time zone")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("ProjectNatureId")]
        [InverseProperty("ProjectTypes")]
        public virtual ProjectNature? ProjectNature { get; set; }

        [InverseProperty("ProjectType")]
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
