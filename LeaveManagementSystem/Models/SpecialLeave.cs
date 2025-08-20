using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("special_leaves")]
    public class SpecialLeave
    {
        [Key]
        [Column("special_leave_id")]
        public int SpecialLeaveId { get; set; }

        [Column("special_date")]
        public DateTime SpecialDate { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("is_weekend")]
        public bool IsWeekend { get; set; } = false;

        [Column("is_mandatory")]
        public bool IsMandatory { get; set; } = false;

        [Column("company_id")]
        public int CompanyId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
