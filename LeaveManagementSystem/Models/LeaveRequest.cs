using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("leave_requests")]
    public class LeaveRequest
    {
        [Key]
        [Column("request_id")]
        public Guid RequestId { get; set; }

        [Column("request_group_id")]
        public Guid RequestGroupId { get; set; }

        [Column("leave_type_id")]
        public int LeaveTypeId { get; set; }

        [Column("leave_date")]
        public DateTime LeaveDate { get; set; }

        [Column("is_half_day")]
        public bool IsHalfDay { get; set; } = false;

        [MaxLength(20)]
        [Column("half_day_type")]
        public string? HalfDayType { get; set; } // "Morning", "Afternoon", null

        [Column("reason")]
        public string? Reason { get; set; }

        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; } = "Pending";

        [Column("requested_at")]
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        [Column("approver1_id")]
        public Guid? Approver1Id { get; set; }

        [Column("approver2_id")]
        public Guid? Approver2Id { get; set; }

        [Column("approved_at")]
        public DateTime? ApprovedAt { get; set; }

        [Column("rejected_at")]
        public DateTime? RejectedAt { get; set; }

        [Column("rejection_reason")]
        public string? RejectionReason { get; set; }

        [Column("comments")]
        public string? Comments { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("RequestGroupId")]
        public virtual LeaveRequestGroup RequestGroup { get; set; } = null!;

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType { get; set; } = null!;

        [ForeignKey("Approver1Id")]
        public virtual Employee? Approver1 { get; set; }

        [ForeignKey("Approver2Id")]
        public virtual Employee? Approver2 { get; set; }
    }
}
