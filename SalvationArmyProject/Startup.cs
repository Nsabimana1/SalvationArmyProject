﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalvationArmyProject.Entities;
using SalvationArmyProject.SeedData;
using SalvationArmyProject.Services;

namespace SalvationArmyProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IEventRepository, EventRepositry>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IEventRequestRepository, EventRequestRepository>();
            services.AddScoped<IEventResponseRepository, EventResponseRepository>();


            //string connectionString = Startup.Configuration["connectionStrings:DBConnectionString"];
            //services.AddDbContext<DBcontext>(o => o.UseSqlServer(connectionString));

            string connectionString = Startup.Configuration["connectionStrings:DBConnectionString"];
            services.AddDbContext<DBcontext>(o =>
            {
                o.UseSqlite(connectionString, x => x.SuppressForeignKeyEnforcement());
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<DBcontext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DBcontext databasecontext)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            databasecontext.EnsureSeedDataForContext();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseStatusCodePages();
            app.UseCors();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
