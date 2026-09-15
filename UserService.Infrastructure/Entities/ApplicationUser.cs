using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Infrastructure.Entities.Enums;

namespace UserService.Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        public UserProfile? Profile { get; set; }
    }
}
