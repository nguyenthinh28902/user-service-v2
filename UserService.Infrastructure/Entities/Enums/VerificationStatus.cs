using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Infrastructure.Entities.Enums
{
    public enum VerificationStatus
    {
        [Description("Chưa khai báo thông tin")]
        [Display(Name = "verification.not_provided")]
        NotProvided = 0,
        [Description("Đã khai báo thông tin")]
        [Display(Name = "verification.provided")]
        Provided = 1,
        [Description("Đã xác thực")]
        [Display(Name = "verification.verified")]
        Verified = 2,
        [Description("Bị từ chối")]
        [Display(Name = "verification.rejected")]
        Rejected = 3
    }
}
