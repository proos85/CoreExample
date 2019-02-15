using System.Reflection;
using AutoMapper;
using CoreExample.Core;
using CoreExample.Website.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreExample.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /* Configure OOB .NET Core IoC container to register ILoggingService as transient (every time the interface is injected, a new instance will be created) */
            //services.AddTransient<ILoggingService, FileSystemLoggingService>();

            /* Configure OOB .NET Core IoC container to register ILoggingService as scoped (means there is always one instance during the request lifetime) */
            services.AddScoped<ILoggingService, FileSystemLoggingService>();
            services.AddScoped<ISuperHeroService, SuperHeroService>();
            
            /* Configure OOB .NET Core IoC container to register ILoggingService as singleton (means there is always one instance during the complete lifetime) */
            //services.AddSingleton<ILoggingService, FileSystemLoggingService>();

            /* Configure AutoMapper to look for every Profile class */
            Mapper.Initialize(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
