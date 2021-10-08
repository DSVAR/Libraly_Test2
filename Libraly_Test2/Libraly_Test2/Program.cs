using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly_Test2.Init;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Libraly_Test2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           IHost webHost= CreateHostBuilder(args).Build();
           using (var scoped=webHost.Services.CreateScope())
           {
               var con = scoped.ServiceProvider.GetService<UserRole>();
               await con.CheckValue();
           }
           webHost.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.AddDebug();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}