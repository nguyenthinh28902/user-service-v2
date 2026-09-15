using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserService.Infrastructure.Entities.Enums;

namespace UserService.Infrastructure.Entities
{

    [Table("UserProfiles")]
    public class UserProfile
    {
        // Khóa chính và khóa ngoại liên kết với ApplicationUser
        [Key]
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserId { get; set; } 

        // Loại giấy tờ định danh
        public IdentityDocumentType? IdentityDocumentType { get; set; }

        // Họ
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        // Tên đệm
        [MaxLength(100)]
        public string MiddleName { get; set; } = null!;

        // Tên
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        // Họ và tên đầy đủ
        [MaxLength(255)]
        public string FullName { get; set; } = string.Empty;

        // Tên hiển thị
        [MaxLength(255)]
        public string DisplayName { get; set; } = string.Empty;

        // Ngày sinh
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        // Giới tính
        [MaxLength(20)]
        public string? Gender { get; set; }

        // Quốc tịch
        [Required]
        [MaxLength(2)]
        public string NationalityCode { get; set; } = "VN";

        // Số căn cước công dân
        [MaxLength(20)]
        public string? CitizenId { get; set; }

        // Ngày cấp căn cước công dân
        public DateOnly? CitizenIdIssuedDate { get; set; }

        // Nơi cấp căn cước công dân
        [MaxLength(255)]
        public string? CitizenIdIssuedPlace { get; set; }

        // Nơi sinh
        [MaxLength(255)]
        public string? PlaceOfBirth { get; set; }

        // Tỉnh/Thành phố quê quán
        [MaxLength(100)]
        public string? HometownProvince { get; set; }

        // Phường/Xã quê quán
        [MaxLength(100)]
        public string? HometownWard { get; set; }

        // Địa chỉ cụ thể quê quán
        [MaxLength(500)]
        public string? HometownAddress { get; set; }

        // Tỉnh/Thành phố thường trú
        [MaxLength(100)]
        public string? PermanentProvince { get; set; }

        // Phường/Xã thường trú
        [MaxLength(100)]
        public string? PermanentWard { get; set; }

        // Địa chỉ cụ thể thường trú
        [MaxLength(500)]
        public string? PermanentAddress { get; set; }

        // Tỉnh/Thành phố nơi sinh
        [MaxLength(100)]
        public string? PlaceOfBirthProvince { get; set; }

        // Phường/Xã nơi sinh
        [MaxLength(100)]
        public string? PlaceOfBirthWard { get; set; }

        // Địa chỉ cụ thể nơi sinh
        [MaxLength(500)]
        public string? PlaceOfBirthAddress { get; set; }

        // Đường dẫn ảnh đại diện
        [Url]
        [MaxLength(1000)]
        public string? AvatarUrl { get; set; }

        // Trạng thái xác thực thông tin
        [Required]
        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Provided;

        // Đánh dấu bản ghi đã bị xóa
        public bool IsDeleted { get; set; } = false;

        // Thời điểm tạo hồ sơ
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời điểm cập nhật hồ sơ gần nhất
        public DateTime? UpdatedAt { get; set; }

        // User sở hữu hồ sơ
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }

}
