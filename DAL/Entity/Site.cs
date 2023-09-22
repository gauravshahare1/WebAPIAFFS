using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAFFS.DAL.Entity
{
    [Table("sites")]
    public class Site
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("district_id")]
        public Guid? DistrictId { get; set; }

        [Column("project_id")]
        public Guid? ProjectId { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp without time zone")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("DistrictId")]
        [InverseProperty("Sites")]
        public virtual District? District { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("Sites")]
        public virtual Project? Project { get; set; }
    }
}
