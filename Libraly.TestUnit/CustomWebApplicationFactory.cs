using System.IO;
using System.Net.Http;
using System.Reflection;
using Libraly.TestUnit.Interfaces;
using Libraly_Test2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libraly.TestUnit
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public TestServer TestServer { get; }
        public HttpClient Client { get; }
        

        public CustomWebApplicationFactory()
        {
            if (TestServer == null && Client == null)
            {
                var builder = new WebHostBuilder()
                    .UseEnvironment("Testing")
                    .ConfigureAppConfiguration((context, configBuilder) =>
                    {
                        configBuilder.SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                        
                    })
                    .ConfigureServices(Services=>Services.AddTransient(typeof(IHttpResponse), typeof(HttpResponse)))
                    .UseStartup<Startup>();
                
            
                TestServer = new TestServer(builder);
                Client = TestServer.CreateClient();
                
                
            }
        }
        
        public void Dispose()
        {
            Client.Dispose();
            TestServer.Dispose();
        }
    }
}