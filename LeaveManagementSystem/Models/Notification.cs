using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    [Table("notifications")]
    public class Notification
    {
        [Key]
        [Column("notification_id")]
        public Guid NotificationId { get; set; }

        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("notification_type")]
        public string NotificationType { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("message")]
        public string Message { get; set; } = string.Empty;

        [Column("is_read")]
        public bool IsRead { get; set; } = false;

        [Column("related_request_group_id")]
        public Guid? RelatedRequestGroupId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("read_at")]
        public DateTime? ReadAt { get; set; }

        // Navigation Properties
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; } = null!;

        [ForeignKey("RelatedRequestGroupId")]
        public virtual LeaveRequestGroup? RelatedRequestGroup { get; set; }
    }
}
