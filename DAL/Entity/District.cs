using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.DAL.Entity
{
    [Table("districts")]
    public class District
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

        [InverseProperty("District")]
        public virtual ICollection<Site> Sites { get; set; } = new List<Site>();
    }
}
