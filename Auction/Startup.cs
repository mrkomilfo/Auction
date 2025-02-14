﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Auction.Data.DB;
using Auction.Data.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Auction.Data;
using Auction.Hubs;

namespace Auction
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment env { get; set; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddLocalization(options => options.ResourcesPath = "Resources");           

            var supportedCultures = new[]
            {
                new CultureInfo("be"),
                new CultureInfo("en"),
                new CultureInfo("ru")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("ru");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequiredLength = 5;   // минимальная длина
                options.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                options.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                options.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                options.Password.RequireDigit = false; // требуются ли цифры
            }).AddEntityFrameworkStores<ApplicationContext>();
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });
           

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                 .AddViewLocalization()
                 .AddDataAnnotationsLocalization();
            services.AddMvc().AddViewLocalization();
            services.AddMvc();

            services.AddSignalR();

            services.AddTransient<Dict>();

            services.AddSingleton<IHostingEnvironment>(env);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Account/Error");
                app.UseHsts();
            }
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseSignalR(route =>
            {
                route.MapHub<NotificationHub>("/notifications");
                route.MapHub<UpdateHub>("/updates");
            });

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Lots}/{action=Actual}/{id?}");
                routes.MapRoute(name: "actualLots", template: "Lots/Actual/{id:int?}", defaults: new { Controller = "Lots", Action = "Actual"});
                routes.MapRoute(name: "endedLots", template: "Lots/Ended/{id:int?}", defaults: new {Controller = "Lots", Action = "Ended" });
                routes.MapRoute(name: "loadLots", template: "Lots/Load/{id:int?}", defaults: new { Controller = "Lots", Action = "Load" });
                routes.MapRoute(name: "lotDetail", template: "Lot/{id:int}", defaults: new { Controller = "Lots", Action = "Detail" });
                routes.MapRoute(name: "lotCreate", template: "Lot/Create", defaults: new { Controller = "Lots", Action = "Create" });
                routes.MapRoute(name: "usersList", template: "Users/Index", defaults: new { Controller = "Users", Action = "Index" });
                routes.MapRoute(name: "profile", template: "Users/Profile/{id}", defaults: new { Controller = "Users", Action = "Profile" });
                routes.MapRoute(name: "roles", template: "Users/Roles", defaults: new { Controller = "Users", Action = "Roles" });
                routes.MapRoute(name: "myProfile", template: "Account/Profile", defaults: new { Controller = "Account", Action = "Profile" });
                routes.MapRoute(name: "login", template: "Account/Login", defaults: new { Controller = "Account", Action = "Login" });
                routes.MapRoute(name: "register", template: "Account/Register", defaults: new { Controller = "Account", Action = "Register" });
                routes.MapRoute(name: "edit", template: "Account/Edit", defaults: new { Controller = "Account", Action = "Edit" });
                routes.MapRoute(name: "changePassword", template: "Account/ChangePassword", defaults: new { Controller = "Account", Action = "ChangePassword" });
            });
        }
    }
}
