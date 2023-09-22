using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.DAL.Entity
{
    [Table("financial_years")]
    public class FinancialYear
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }

        [Column("is_active")]
        public bool? IsActive { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp without time zone")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("FinancialYear")]
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
