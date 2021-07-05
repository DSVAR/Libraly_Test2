using System.Linq;
using System.Threading.Tasks;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Libraly.Data.Entities;

namespace Libraly_Test2.Controllers
{
    [ApiController]
    [Route("/test/")]
    public class TestController : ControllerBase
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
        [Route("getusers")]
        public IQueryable<User> GetUser()
        {
            var users = _userService.GetUsers();
            return users;
            //   return null;
        }

        [Route("create")]
        public async Task<ActionResult> Create(RegisterViewModel user)
        {
           // ModelState.AddModelError("swe","ssssss");
  
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(user);
                return Ok(user);
            }

            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}