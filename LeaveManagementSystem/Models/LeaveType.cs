using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("leave_types")]
    public class LeaveType
    {
        [Key]
        [Column("leave_type_id")]
        public int LeaveTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("leave_type_name")]
        public string LeaveTypeName { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Column("max_days_per_year")]
        public int MaxDaysPerYear { get; set; }

        [Column("is_paid_leave")]
        public bool IsPaidLeave { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; } = new List<LeaveBalance>();
    }
}
