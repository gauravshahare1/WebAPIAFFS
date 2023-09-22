using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.DAL.Entity
{
    [Table("projects")]
    public class Project
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("mode", TypeName = "char")]
        public char? Mode { get; set; }

        [Column("department_id")]
        public Guid? DepartmentId { get; set; }

        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }

        [Column("project_nature_id")]
        public Guid? ProjectNatureId { get; set; }

        [Column("project_type_id")]
        public Guid? ProjectTypeId { get; set; }

        [Column("description", TypeName = "character varying")]
        public string? Description { get; set; }

        [Column("financial_year_id")]
        public Guid? FinancialYearId { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [Column("update_at", TypeName = "timestamp without time zone")]
        public DateTime? UpdateAt { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("Projects")]
        public virtual Department? Department { get; set; }

        [ForeignKey("FinancialYearId")]
        [InverseProperty("Projects")]
        public virtual FinancialYear? FinancialYear { get; set; }

        [ForeignKey("ProjectNatureId")]
        [InverseProperty("Projects")]
        public virtual ProjectNature? ProjectNature { get; set; }

        [ForeignKey("ProjectTypeId")]
        [InverseProperty("Projects")]
        public virtual ProjectType? ProjectType { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<Site> Sites { get; set; } = new List<Site>();
    }
}
