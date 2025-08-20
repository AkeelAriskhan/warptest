using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("company_holidays")]
    public class CompanyHoliday
    {
        [Key]
        [Column("holiday_id")]
        public int HolidayId { get; set; }

        [Required]
        [Column("holiday_date")]
        public DateTime HolidayDate { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("holiday_name")]
        public string HolidayName { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Column("is_recurring")]
        public bool IsRecurring { get; set; } = false;

        [Column("is_weekend")]
        public bool IsWeekend { get; set; } = false;

        [Column("compensated_if_on_weekend")]
        public bool CompensatedIfOnWeekend { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
