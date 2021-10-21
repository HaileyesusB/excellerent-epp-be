using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Excellerent.APIModularization
{

    /// <summary>
    ///  Interface to specify available StartUp methods
    /// </summary>
    public interface IModuleStartup
    {
        void Startup(IConfiguration configuration);

        void ConfigureServices(IServiceCollection services);

        void ConfigureDependencyInjection(IServiceCollection services);

        void Configure(IApplicationBuilder app, IWebHostEnvironment env);

    }
}