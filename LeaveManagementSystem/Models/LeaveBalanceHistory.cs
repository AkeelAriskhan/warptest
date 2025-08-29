using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("leave_balance_history")]
    public class LeaveBalanceHistory
    {
        [Key]
        [Column("history_id")]
        public Guid HistoryId { get; set; }

        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Column("leave_type_id")]
        public int LeaveTypeId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("action_type")]
        public string ActionType { get; set; } = string.Empty; // "Allocated", "Used", "Adjusted", "Carried_Forward"

        [Column("days_changed", TypeName = "decimal(5,2)")]
        public decimal DaysChanged { get; set; }

        [Column("balance_before", TypeName = "decimal(5,2)")]
        public decimal BalanceBefore { get; set; }

        [Column("balance_after", TypeName = "decimal(5,2)")]
        public decimal BalanceAfter { get; set; }

        [Column("reason")]
        public string? Reason { get; set; }

        [Column("changed_by")]
        public Guid ChangedBy { get; set; }

        [Column("changed_at")]
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; } = null!;

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType { get; set; } = null!;

        [ForeignKey("ChangedBy")]
        public virtual Employee ChangedByEmployee { get; set; } = null!;
    }
}
