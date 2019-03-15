using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintain.NET.Data;
using Maintain.NET.Models;
using Maintain.NET.Models.Interfaces;
using Maintain.NET.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maintain.NET
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityMaintainDbContext>()
                .AddDefaultTokenProviders();

            //Add Email Here
            services.AddScoped<IEmailSender, EmailSender>();

            //Add Authorization Here


            //Add Dependency Injection Here
            services.AddScoped<ITaskManager, TaskManagementService>();
            services.AddScoped<IUserTaskManager, UserTaskManagementService>();

            // Switches between connection strings.
            bool usingProduction = true;

            //*********************DEFAULT CONNECTION STRINGS******************************************************************
            if (!usingProduction)
            {
                // Add default connection strings here.
                services.AddDbContext<MaintainDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
                services.AddDbContext<IdentityMaintainDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:IdentityDefaultConnection"]));

            }

            //*********************PRODUCTION CONNECTION STRINGS***************************************************************
            if (usingProduction)
            {
                // Add production connection strings here.
                services.AddDbContext<MaintainDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ProductionConnection"]));
                services.AddDbContext<IdentityMaintainDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:IdentityProductionConnection"]));

            }
            // for making dropdown ??? hope so...
            //var connection = Configuration.GetConnectionString("DatabaseConnection");
            //services.AddDbContext<MaintenanceTask>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
