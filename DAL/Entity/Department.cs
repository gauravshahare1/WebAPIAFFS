using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.DAL.Entity
{
    [Table("departments")]
    public class Department
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }

        [Column("ref_code", TypeName = "character varying")]
        public string? RefCode { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp without time zone")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
