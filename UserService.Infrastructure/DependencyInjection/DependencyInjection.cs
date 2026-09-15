using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using UserService.Infrastructure.Dbcontext;
using UserService.Infrastructure.Entities;
using UserService.Infrastructure.Persistence.Interceptors;
using UserService.Infrastructure.Persistence.UnitOfWork;

namespace UserService.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Đăng ký AuditSaveChangesInterceptor để sử dụng trong DbContext
            services.AddScoped<AuditSaveChangesInterceptor>();
            services.AddDbContext<UserDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
                options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging(); //ghi log các câu truy vấn SQL và thông tin nhạy cảm
                options.AddInterceptors(
                    serviceProvider.GetRequiredService<AuditSaveChangesInterceptor>());
            });
            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
             .AddRoles<IdentityRole<Guid>>()
             .AddEntityFrameworkStores<UserDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
