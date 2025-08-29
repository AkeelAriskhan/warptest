using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("leave_balances")]
    public class LeaveBalance
    {
        [Key]
        [Column("balance_id")]
        public Guid BalanceId { get; set; }

        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Column("leave_type_id")]
        public int LeaveTypeId { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("allocated_days", TypeName = "decimal(5,2)")]
        public decimal AllocatedDays { get; set; }

        [Column("used_days", TypeName = "decimal(5,2)")]
        public decimal UsedDays { get; set; } = 0;

        [Column("pending_days", TypeName = "decimal(5,2)")]
        public decimal PendingDays { get; set; } = 0;

        [Column("remaining_days", TypeName = "decimal(5,2)")]
        public decimal RemainingDays { get; set; }

        [Column("carried_forward_days", TypeName = "decimal(5,2)")]
        public decimal CarriedForwardDays { get; set; } = 0;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; } = null!;

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType { get; set; } = null!;
    }
}
