using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.UserDTO;
using Libraly.BLL.Services;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Libraly_Test2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserC : Controller
    {
        private readonly IUserService _userService;

        public UserC(IUserService userService)
        {
            _userService = userService;
        }

        // GET — получение ресурса
        // POST — создание ресурса
        // PUT — обновление ресурса
        // DELETE — удаление ресурса

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {            
            return Ok(JsonConvert.SerializeObject(new {Users = await _userService.GetUsers() }) );
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(RegisterViewModel user)
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
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }
            }

            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpGet]
        [Route("FindUser/{email}")]
        public Task<User> FindUser(string email)
        {
            return _userService.FindUser(email);
        }

        [HttpDelete]
        [Route("DeleteUser/{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var user = await _userService.FindUser(email);
            if (user != null)
            {
                var result = await _userService.DeleteUser(user);
                if (result.Succeeded)
                {
                    return Ok(user);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }
            }

            else
            {
                return BadRequest("Not found user!");
            }
        }


        [HttpPost]
        [Route("CreateRole")]
        public Task<IdentityResult> CreateRole(IdentityRole roleName)
        {
            return _userService.CreateRole(roleName.Name);
        }

        [HttpDelete]
        [Route("DeleteRole/{name}")]
        public async Task<IdentityResult> DeleteRole(string name)
        {
            return await _userService.DeleteRole(name);
        }

        [HttpPost]
        [Route("AddToRole")]
        public async Task<IdentityResult> AddToRole(AddToRoleViewModel user)
        {
            return await _userService.AddToRole(user);
        }
        
        [HttpGet]
        [Route("FindRole/{name}")]
        public async Task<IdentityRole> FindRole(string name)
        {
            return await _userService.FindRole(name);
        }
    }
}