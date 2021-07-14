using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly.Data.Entities;
using Libraly_Test2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Libraly.TestUnit
{
    public class TestWebApplicaton: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public TestWebApplicaton(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Dead()
        {
             
            try
            {
             
                var response = await _factory.Client.GetAsync("/Test/GetUsers");
 //               var models = JsonConvert.DeserializeObject<IQueryable<User>>(await response.Content.ReadAsStringAsync());

                var responseBody =await response.Content.ReadAsStringAsync();
                
                var jObject = JsonConvert.DeserializeObject(responseBody);
                
                // Assert  
                response.EnsureSuccessStatusCode();
              //  Assert.NotEmpty(models);
              Assert.NotNull(jObject);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
         
        //    var models = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(await response.Content.ReadAsStringAsync());
            // Assert
        //    Assert.NotEmpty(models);
        }
    }
}