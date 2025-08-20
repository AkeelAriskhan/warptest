using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("departments")]
    public class Department
    {
        [Key]
        [Column("department_id")]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("department_name")]
        public string DepartmentName { get; set; } = string.Empty;

        [Column("total_employees")]
        public int TotalEmployees { get; set; } = 0;

        [Column("department_head_id")]
        public Guid? DepartmentHeadId { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("DepartmentHeadId")]
        public virtual Employee? DepartmentHead { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
