using System.Linq;
using System.Threading.Tasks;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Libraly.Data.Entities;

namespace Libraly_Test2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private IUserService _userService;


        public TestController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("{ortes}")]
        public int Test(int ortes)
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
        [Route("GetUsers")]
        // public IQueryable<User> GetUser()
        // {
        //     var users =  _userService.GetUsers();
        //     return users;
        //     //   return null;
        // }

        [Route("Create")]
        public async Task<ActionResult> Create(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(user);
                if (result.Succeeded)
                {
                    return Ok(user);
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code,error.Description);
                    }

                    return BadRequest(ModelState);
                }
               
            }

            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}