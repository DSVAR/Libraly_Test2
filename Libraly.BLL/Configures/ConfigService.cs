using Libraly.Data.Context;
using Libraly.Data.Entities;
using Libraly.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libraly.BLL.Configures
{
    public static class ConfigService
    {
        public static IServiceCollection InitServices(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Libraly.Data")
                ));

            services.AddIdentity<User, IdentityRole>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();
            

            services.AddSingleton(typeof(IUnitOfWork<>), typeof(IUnitOfWork<>));
            
            return services;
        }
        
       
    }
}