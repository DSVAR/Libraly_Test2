using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Libraly.BLL.Models.UserDTO;
using Libraly_Test2;
using Xunit;
using Xunit.Extensions.Ordering;

namespace Libraly.TestUnit.UserController
{
    public class TestUser 
    {
        private readonly HttpResponse _response=new HttpResponse(new CustomWebApplicationFactory<Startup>());
        
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

        public TestUser()
        {
        }
       

        [Fact, Order(1)]
        public async Task CreateUser()
        {
            try
            {
                var responseBody = await _response.HttpPost(_user, "/UserC/CreateUser");
                //  Assert
                Assert.Equal(201, _response.JsonAnswer(responseBody));
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
                var responseBody =await _response.HttpGet("/UserC/GetUsers");
                // Assert  
                Assert.Equal(200,_response.JsonAnswer(responseBody));
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
                var responseBody = await _response.HttpGet($"/UserC/FindUser/{_user.Email}");
                // Assert  
                Assert.Equal(200,_response.JsonAnswer(responseBody));
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
                var responseBody = await _response.HttpPost(_role, "/UserC/CreateRole");
                //  Assert.NotEmpty(models);
                Assert.Equal(201,_response.JsonAnswer(responseBody));
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
                var responseBody = await _response.HttpGet($"/UserC/FindRole/{name}");
                Assert.Equal(200,_response.JsonAnswer(responseBody));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [Fact, Order(6)]
        public async Task AddToRole()
        {
            var responseBody = await _response.HttpPost(_userRole, "/UserC/AddToRole");
            Assert.Equal(200,_response.JsonAnswer(responseBody));
        }
        
        [Theory, Order(7)]
        [InlineData("OBSERV")]
        public async Task DeleteRole(string name)
        {
            try
            {
                var responseBody =await _response.HttpDelete($"/UserC/DeleteRole/{name}");
                Assert.Equal(202,_response.JsonAnswer(responseBody));
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
                var responseBody = await _response.HttpDelete($"/UserC/DeleteUser/{_user.Email}");
                // Assert  
                Assert.Equal(202,_response.JsonAnswer(responseBody));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
        [Fact, Order(9)]
        public async Task RemoveToRole()
        {
            var responseBody =await _response.HttpPost(_userRole, "UserC/RemoveFromRole");
            Assert.Equal(202,_response.JsonAnswer(responseBody));
        }
    }
}