using Excellerent.APIModularization;
using Excellerent.UserManagement.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace excellerent_epp_be
{
    public partial class Startup
    {
        private IList<IModuleStartup> modules = new List<IModuleStartup>();

        public void AddModules(IServiceCollection services)
        {
            modules.Add(new UserManagementModule());

            ConfigureModules(services);
        }

        public void ConfigureModules(IServiceCollection services)
        {
            // find all controllers
            var Controllers = from a in AppDomain.CurrentDomain.GetAssemblies().AsParallel()
                              from t in a.GetTypes()
                              let attributes = t.GetCustomAttributes(typeof(ControllerAttribute), true)
                              where attributes?.Length > 0
                              select new { Type = t };
            var ControllersList = Controllers.ToList();

            // register them
            foreach (var Controller in ControllersList)
            {
                services
                    .AddMvc()
                    .AddApplicationPart(Controller.Type.Assembly);
            }

            // configuring services for all modules
            foreach (var module in modules)
            {
                module.Startup(Configuration);
                module.ConfigureServices(services);
            }
        }
    }
}
