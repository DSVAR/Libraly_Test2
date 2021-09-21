using Libraly.BLL.Interfaces;
using Libraly.BLL.Services;
using Libraly.Data.Context;
using Libraly.Data.Entities;
using AutoMapper;
using Libraly.BLL.Models.BookDTO;
using Libraly.Data.Interfaces;
using Libraly.Data.Repositories;
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
           
           services.AddIdentity<User, IdentityRole>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

           services.AddAutoMapper(typeof(ConfigureOfMapping));
           services.AddTransient<ConfigureOfMapping>();

           services.AddTransient(typeof(IUserService), typeof(UserService));
           services.AddTransient(typeof(IBookService), typeof(BookService));
           services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
           
         // services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWorkRepo));
           services.AddTransient<IUnitOfWork,UnitOfWorkRepo>();
       //    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
           
           
           // services.AddScoped(typeof(IUserService), typeof(UserService));
           // services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWorkRepo<>));
            return services;
        }
        
       
    }
}