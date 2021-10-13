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
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Extensions.Ordering;

namespace Libraly.TestUnit.UserController
{
    public class TestUser : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        private static readonly RegisterViewModel _user = new RegisterViewModel
        {
            FirstName = "Test First Name",
            UserName = "Tests7",
            Surname = "Test4",
            FullName = "Test Full Name",
            Email = "sobakens@gmail.com",
            Password = "Kavo2535",
            ConfirmPassword = "Kavo2535"
        };

        private readonly RoleViewModel _userRole = new RoleViewModel
        {
            Email = _user.Email,
            RoleName = "Admin"
        };

        private readonly Dictionary<string, string> _role = new Dictionary<string, string>
        {
            {"Name", "OBSERV"}
        };

        public TestUser(CustomWebApplicationFactory<Startup> factory)
        {
          
               _factory = factory;
          
        }


        [Fact, Order(1)]
        public async Task CreateUser()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //arrange
                var response = await _factory.Client.PostAsync("/UserC/CreateUser", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var jObject = JsonConvert.DeserializeObject(responseBody);
                    var token = JObject.Parse(jObject.ToString());
                    //  var succeeded = bool.Parse(token["succeeded"].ToString());
                    var user = token.ToObject<RegisterViewModel>();

                    // Assert  

                    //  Assert.NotEmpty(models);
                    Assert.Equal(_user.UserName, user.UserName);
                }
                else
                {
                    throw new Exception(responseBody);
                    //  Console.Write(responseBody);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        [Fact, Order(2)]
        public async Task GetUsers()
        {
            try
            {
                // Arrange 
                var response = await _factory.Client.GetAsync("/UserC/GetUsers");
                var responseBody = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseBody);
                //var jObject = JsonConvert.DeserializeObject(responseBody);
                var token = JObject.Parse(jObject.ToString());
                var isUser = token["Users"].Count() > 0 ? true : false;
                // Assert  

                // Assert.True(succeeded);
                Assert.True(isUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [Fact, Order(3)]
        public async Task FindUser()
        {
            try
            {
                // Arrange 
                var response = await _factory.Client.GetAsync($"/UserC/FindUser/{_user.Email}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var jObject = JsonConvert.DeserializeObject(responseBody);
                var token = JObject.Parse(jObject.ToString());
                var user = token.ToObject<RegisterViewModel>();

                // Assert  

                //  Assert.NotEmpty(models);
                Assert.Equal(_user.UserName, user.UserName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


       
        [Fact, Order(4)]
        public async Task CreateRole()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_role);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _factory.Client.PostAsync($"/UserC/CreateRole", content);
                var responseBody = await response.Content.ReadAsStringAsync();
                var jObject = JsonConvert.DeserializeObject(responseBody);
                var token = JObject.Parse(jObject.ToString());
                var succeeded = bool.Parse(token["succeeded"].ToString());
                // Assert  

                //  Assert.NotEmpty(models);
                Assert.True(succeeded);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [Theory, Order(5)]
        [InlineData("OBSERV")]
        public async Task FindRole(string name)
        {
            try
            {
                var response = await _factory.Client.GetAsync($"/UserC/FindRole/{name}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var jObject = JsonConvert.DeserializeObject(responseBody);
                var token = JObject.Parse(jObject.ToString());
                var succeeded = token["name"].ToString();
                Assert.Equal(succeeded, name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        [Fact, Order(6)]
        public async Task AddToRole()
        {
            var json =JsonConvert.SerializeObject(_userRole) ;
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _factory.Client.PostAsync($"/UserC/AddToRole", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var jObject = JsonConvert.DeserializeObject(responseBody);
            var token = JObject.Parse(jObject.ToString());
            var succeeded = bool.Parse(token["succeeded"].ToString());
            
            Assert.True(succeeded);
        }

        [Theory, Order(7)]
        [InlineData("OBSERV")]
        public async Task DeleteRole(string name)
        {
            try
            {
                var response = await _factory.Client.DeleteAsync($"/UserC/DeleteRole/{name}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var jObject = JsonConvert.DeserializeObject(responseBody);
                var token = JObject.Parse(jObject.ToString());
                var succeeded = bool.Parse(token["succeeded"].ToString());
                // Assert  

                //  Assert.NotEmpty(models);
                Assert.True(succeeded);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
        [Fact, Order(8)]
        public async Task DeleteUser()
        {
            try
            {
                //Arrange
                var response = await _factory.Client.DeleteAsync($"/UserC/DeleteUser/{_user.Email}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var jObject = JsonConvert.DeserializeObject(responseBody);
                // Assert  
                var token = JObject.Parse(jObject.ToString());
                var user = token.ToObject<RegisterViewModel>();

                // Assert  

                //  Assert.NotEmpty(models);
                Assert.Equal(_user.UserName, user.UserName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [Fact,Order(9)]
        public async Task RemoveToRole()
        {
            var json =JsonConvert.SerializeObject(_userRole) ;
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _factory.Client.PostAsync("UserC/RemoveFromRole",content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var jObject = JsonConvert.DeserializeObject(responseBody);
            var token = JObject.Parse(jObject.ToString());
            var succeeded = bool.Parse(token["succeeded"].ToString());
            
            Assert.True(succeeded);
        }
    }
}