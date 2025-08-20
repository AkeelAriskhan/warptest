using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("employee_name")]
        public string EmployeeName { get; set; } = string.Empty;

        [Column("age")]
        public int Age { get; set; }

        [Column("department_id")]
        public int DepartmentId { get; set; }

        [Column("manager_id")]
        public Guid? ManagerId { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [MaxLength(100)]
        [Column("job_title")]
        public string JobTitle { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column("employment_status")]
        public string EmploymentStatus { get; set; } = "Active";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; } = null!;

        [ForeignKey("ManagerId")]
        public virtual Employee? Manager { get; set; }

        // Collections
        public virtual ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
        public virtual ICollection<LeaveRequestGroup> LeaveRequestGroups { get; set; } = new List<LeaveRequestGroup>();
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; } = new List<LeaveBalance>();
        public virtual ICollection<LeaveApproval> LeaveApprovals { get; set; } = new List<LeaveApproval>();
    }
}
