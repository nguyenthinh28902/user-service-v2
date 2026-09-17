using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Infrastructure.Entities
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Key định danh duy nhất dùng để check code, ví dụ: "Product.Create", "Order.Approve"
        [Required]
        [MaxLength(25)]
        public string Key { get; set; } = string.Empty;

        // Tên hiển thị tiếng Việt trên giao diện, ví dụ: "Thêm sản phẩm"
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Nhóm module để gom cụm trên UI, ví dụ: "Quản lý sản phẩm", "Quản lý đơn hàng"
        [Required]
        [MaxLength(150)]
        public string Module { get; set; } = string.Empty;

        [Required]
        public string? Description { get; set; }
    }
}
