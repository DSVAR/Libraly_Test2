using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Libraly.BLL.Models.UserDTO;
using Libraly.Data.Entities;
using Libraly_Test2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Libraly.TestUnit
{
    public class TestWebApplicaton : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        
        private Dictionary<string,string> _user = new Dictionary<string, string>
        {
            {"FirstName", "Test First Name"},
            {"UserName","Tests6"},
            {"Surname","Test4"},
            {"FullName" ,"Test Full Name"},
            {"Email" ,"sobakens@gmail.com"},
            {"Password" ,"Kavo2535"},
            {"ConfirmPassword" ,"Kavo2535"},
        };
        
        public TestWebApplicaton(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Dead()
        {
            try
            {
                // Arrange 
                var response = await _factory.Client.GetAsync("/Test/GetUsers");
                var responseBody = await response.Content.ReadAsStringAsync();
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
        }

        [Fact]
        public async Task PostHttp()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //arrange
                var response = await _factory.Client.PostAsync("/Test/Create",content);
                var responseBody = await response.Content.ReadAsStringAsync();
              
                if(response.StatusCode==HttpStatusCode.Accepted){                
                var jObject = JsonConvert.DeserializeObject(responseBody);
                // Assert  
                Assert.NotNull(jObject);
                }
                else
                {
                    throw new Exception(responseBody);
                  //  Console.Write(responseBody);
                }
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}