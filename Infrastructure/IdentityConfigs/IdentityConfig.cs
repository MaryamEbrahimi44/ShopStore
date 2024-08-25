using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.IdentityConfigs
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration configuration)
        {
            string connection = configuration["ConnectionStrings:SqlServer"];


            services.AddDbContext<IdentityDatabaseContext>(options => options.UseSqlServer(connection));


            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDatabaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<CustomIdentityErrors>();


            //services.AddIdentity<User, IdentityUser>()
            //   .AddEntityFrameworkStores<IdentityDatabaseContext>()
            //   .AddDefaultTokenProviders()
            //   .AddErrorDescriber<CustomIdentityErrors>();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            });
            return services;


        }
    }
}
