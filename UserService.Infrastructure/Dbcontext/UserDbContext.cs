using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Infrastructure.Entities;

namespace UserService.Infrastructure.Dbcontext
{
    public class UserDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole<Guid>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            builder.Entity<UserProfile>().ToTable("UserProfiles");
            builder.Entity<AuditLog>().ToTable("AuditLogs");
            builder.Entity<Permission>().ToTable("Permissions");

            builder.Entity<ApplicationUser>()
              .HasOne(u => u.Profile)
              .WithOne(p => p.ApplicationUser)
              .HasForeignKey<UserProfile>(p => p.UserId)
              .OnDelete(DeleteBehavior.Cascade);


            // Tự động cấu hình cho tất cả Entity có Id kiểu Guid
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var primaryKey = entityType.FindPrimaryKey();
                // Nếu bảng có khóa chính đơn (1 cột làm PK) và cột đó có kiểu dữ liệu là Guid
                if (primaryKey != null && primaryKey.Properties.Count == 1)
                {
                    var pkProperty = primaryKey.Properties[0];
                    if (pkProperty.ClrType == typeof(Guid))
                    {
                        //id tuần tự tăng dần (NEWSEQUENTIALID) để tránh tình trạng phân mảnh dữ liệu trong cơ sở dữ liệu
                        //tăng tốc độ lệnh insert.
                        pkProperty.SetDefaultValueSql("NEWSEQUENTIALID()");
                    }
                }
            }
        }
    }
}
