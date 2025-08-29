using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("leave_request_groups")]
    public class LeaveRequestGroup
    {
        [Key]
        [Column("request_group_id")]
        public Guid RequestGroupId { get; set; }

        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Column("total_requests")]
        public int TotalRequests { get; set; }

        [Column("total_days", TypeName = "decimal(5,2)")]
        public decimal TotalDays { get; set; }

        [MaxLength(20)]
        [Column("overall_status")]
        public string OverallStatus { get; set; } = "Pending";

        [Column("requested_at")]
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        [Column("is_responded")]
        public bool IsResponded { get; set; } = false;

        [Column("responded_at")]
        public DateTime? RespondedAt { get; set; }

        [Column("final_approver_id")]
        public Guid? FinalApproverId { get; set; }

        [Column("comments")]
        public string? Comments { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; } = null!;

        [ForeignKey("FinalApproverId")]
        public virtual Employee? FinalApprover { get; set; }

        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public virtual ICollection<LeaveApproval> LeaveApprovals { get; set; } = new List<LeaveApproval>();
    }
}
