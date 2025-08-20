using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("company_weekend_policy")]
    public class CompanyWeekendPolicy
    {
        [Key]
        [Column("policy_id")]
        public int PolicyId { get; set; }

        [Column("office_id")]
        public int OfficeId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("day_of_week")]
        public string DayOfWeek { get; set; } = string.Empty;

        [Column("is_holiday")]
        public bool IsHoliday { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
