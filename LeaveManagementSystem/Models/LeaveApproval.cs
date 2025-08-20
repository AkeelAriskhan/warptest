using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("leave_approvals")]
    public class LeaveApproval
    {
        [Key]
        [Column("approval_id")]
        public Guid ApprovalId { get; set; }

        [Column("request_group_id")]
        public Guid RequestGroupId { get; set; }

        [Column("approver_id")]
        public Guid ApproverId { get; set; }

        [Column("approval_level")]
        public int ApprovalLevel { get; set; } = 1;

        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; } = "Pending";

        [Column("comments")]
        public string? Comments { get; set; }

        [Column("approved_at")]
        public DateTime? ApprovedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("RequestGroupId")]
        public virtual LeaveRequestGroup RequestGroup { get; set; } = null!;

        [ForeignKey("ApproverId")]
        public virtual Employee Approver { get; set; } = null!;
    }
}
