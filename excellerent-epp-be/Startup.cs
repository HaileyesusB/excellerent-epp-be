using Excellerent.APIModularization.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace excellerent_epp_be
{
    public partial class  Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            AddModules(services);
            //Authentication and Identity
            ConfigureAuth(services);
            services.AddControllers()
                 .AddJsonOptions(options =>
                 {
                     options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                     options.JsonSerializerOptions.PropertyNamingPolicy = null;
                     options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                 });

            services.AddHttpContextAccessor();
            services.AddTransient<IBusinessLog, BusinessLog>();
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.FullName.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Excellerent EPP API", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AIC.Fairmart.API v1"));

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            //app.UseHttpsRedirection();

            //Use JWT for this case         
            var jwtOptions = GetTokenProviderOptions();
           // app.UseSimpleTokenProvider(jwtOptions);
            //app.UseMiddleware<TokenProviderMiddleware>(Options.Create(jwtOptions));

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
