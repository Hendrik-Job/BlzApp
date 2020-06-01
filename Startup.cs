using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlzApp.Interfaces;
using BlzApp.Service;
using BlzApp.Models;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using BlzApp.Data;

namespace BlzApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlDbContext")));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<IEmployee, EmployeeDataAccessLayer>();
            services.AddTransient<IAddressService, AddressService>();

            services.AddSingleton<MenuService>();
            //services.AddScoped<Employee>();
            services.AddSingleton<HttpClient>();

            //Sql database connection (name defined in appsettings.json)
            var SqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("SqlDbContext"));
            services.AddSingleton(SqlConnectionConfiguration);

            //Optional for debugging
            services.AddServerSideBlazor(o => o.DetailedErrors = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
