using Excellerent.APIModularization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.UserManagement.API
{
    public class UserManagementModule : ModuleStartup
    {


        public override void ConfigureDependencyInjection(IServiceCollection services)
        {
            //services.AddDbContext<UserManagementsContext>(options =>
            //   options.UseNpgsql(Configuration.GetConnectionString("UserManagement"),
            //   b => b.MigrationsAssembly("AIC.UserManagment.Infrastructure")));

            //services.AddIdentity<ApplicationUser, ApplicationRole>()
            //    .AddEntityFrameworkStores<UserManagementsContext>()
            //    .AddDefaultTokenProviders();

            //services.AddScoped<IEmployeeManagementRepository, EmployeeManagementRepository>();

            //services.AddTransient<IAccountManager, AccountManager>();
            //services.AddTransient<UserManager<ApplicationUser>>();
        }
    }
}
