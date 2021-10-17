using Libraly_Test2.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Libraly.BLL.Configures;
using Libraly.Data.Context;
using Libraly_Test2.Init;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Libraly_Test2
{
    public class Startup
    {
        private readonly IWebHostEnvironment _currentEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment currentEnvironment)
        {
            Configuration = configuration;
            _currentEnvironment = currentEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //настройка сервисов


            ConfigService.InitServices(services, Configuration);
            services.AddScoped<UserRole>();

            SettingBD(services, Configuration);
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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

        //    app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }


        private void SettingBD(IServiceCollection services, IConfiguration configuration)
        {
            if (_currentEnvironment.IsEnvironment("Testing"))
            {
                var connectionString =
                    "Server=localhost; Port=5432; Database=LibrReact; UserID=postgres; Password=password; ";
                services.AddDbContext<ApplicationContext>(
                    options =>
                    {
                        options.UseNpgsql(connectionString,
                            b => b.MigrationsAssembly("Libraly.Data")
                        );
                        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    });
                // костыль и велосипед

              
            }
            else
            {
                services.AddDbContext<ApplicationContext>(
                    options =>
                    {
                        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly("Libraly.Data")
                        );
                        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    }
                );
            }
        }
    }
}