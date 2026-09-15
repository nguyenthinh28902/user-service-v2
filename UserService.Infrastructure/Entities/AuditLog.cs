using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Infrastructure.Entities
{
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;

        // Tên bảng/entity bị thay đổi
        [MaxLength(100)]
        public string EntityName { get; set; } = null!;

        // ID của record bị thay đổi
        [MaxLength(100)]
        public string EntityId { get; set; } = null!;

        // INSERT / UPDATE / DELETE
        [MaxLength(20)]
        public string Action { get; set; } = null!;

        // User thực hiện
        [MaxLength(100)]
        public string? ChangedBy { get; set; }

        public DateTime ChangedAt { get; set; }

        // Dữ liệu trước khi thay đổi
        public string? OldValues { get; set; }

        // Dữ liệu sau khi thay đổi
        public string? NewValues { get; set; }
    }
}
