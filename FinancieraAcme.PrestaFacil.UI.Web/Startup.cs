using FinancieraAcme.PrestaFacil.Domain;
using FinancieraAcme.PrestaFacil.Domain.Interfaces;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.Model;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.Repository;
using FinancieraAcme.PrestaFacil.UI.Web.Data;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace FinancieraAcme.PrestaFacil.UI.Web
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
            //Data sources
            //services.AddDbContext<PrestaFacilDbContext>(options =>
            //options.UseSqlServer(
            //Configuration.GetConnectionString("PrestaFacilDbContextConnection"),
            //        x => x.MigrationsAssembly("FinancieraAcme.PrestaFacil.Infrastructure.Data")
            //       ));
            services.AddDbContext<PrestaFacilDbContext>(
                cfg =>
                {
                    cfg.UseSqlServer(Configuration.GetConnectionString("PrestaFacilDbContextConnection"))
                    .LogTo(Console.WriteLine, LogLevel.Information);
                }
                );

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            //Repositories
            services.AddScoped<IClient, ClientRepository>();
            services.AddScoped<ILoanApplication, LoanApplicationRepository>();
            services.AddScoped<ILoanApplicationParentRepository, LoanApplicationParentRepository>();
            services.AddScoped<ILoanApplicationChildRepository, LoanApplicationChildRepository>();
            //reporitories...

            //Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();//dependency injection

            //Enable session Management
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = System.TimeSpan.FromMinutes(20);
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;

            });
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
