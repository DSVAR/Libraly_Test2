﻿using Libraly.BLL.Interfaces;
using Libraly.BLL.Services;
using Libraly.Data.Context;
using Libraly.Data.Entities;
using AutoMapper;
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
            
            services.AddDbContext<ApplicationContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Libraly.Data")
                ));

           services.AddIdentity<User, IdentityRole>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

           services.AddAutoMapper(typeof(ConfigureOfMapping));

           services.AddTransient(typeof(IUserService), typeof(UserService));
           
           // services.AddScoped(typeof(IUserService), typeof(UserService));
           // services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWorkRepo<>));
            return services;
        }
        
       
    }
}