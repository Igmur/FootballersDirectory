using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using FootballersDirectory.Repository;
using FootballersDirectory.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace FootballersDirectory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string path = Directory.GetCurrentDirectory();

            string defaultConnection = Configuration.GetConnectionString("DefaultConnection").Replace("[DataDirectory]", path);
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(defaultConnection));
            services.AddMvc(optrion => optrion.EnableEndpointRouting = false);

            services.AddControllersWithViews();
            services.AddScoped<IDataBaseWorker, DataBaseWorker>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=List}/{action=Index}/{id?}");
            });
        }
    }
}
