using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.UserDTO;
using Libraly.BLL.Services;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Libraly_Test2.Controllers
{
    [ApiController]
    [Route("/test/")]
    public class TestController
    {
        private IUserService _userService;


        public TestController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("{ortes}")]
        public int test(int ortes)
        {
            if (ortes >= 0)
            {
                return ortes;
            }

            else
            {
                return 1;
            }
        }

        [HttpGet]
        [Route("getusers")]
        public IQueryable<User> getUser()
        {
            var users = _userService.GetUsers();
            return users;
            //   return null;
        }

        [Route("create")]
        public async Task<IdentityResult> Create(RegisterViewModel user)
        {
            var result = await _userService.Create(user);
            
            return result;
            //   return null;
        }
    }
}