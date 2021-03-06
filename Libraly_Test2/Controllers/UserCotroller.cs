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
        private readonly IDefaultJsonPattern _defaultJson;

        public UserC(IUserService userService,IDefaultJsonPattern defaultJson)
        {
            _userService = userService;
            _defaultJson = defaultJson;
        }

        // GET — получение ресурса
        // POST — создание ресурса
        // PUT — обновление ресурса
        // DELETE — удаление ресурса

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _defaultJson.DeffPatternAnswer(200,"Found users",await _userService.GetUsers() ));
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
                    return Ok(await _defaultJson.DeffPatternAnswer(201,"Added"));
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(await _defaultJson.DeffPatternAnswer(400,"Wasn't add user", errors: ModelState));
                }
            }

            else
            {
                return BadRequest(await _defaultJson.DeffPatternAnswer(400,"Can't create user",errors: ModelState));
            }
        }


        [HttpGet]
        [Route("FindUser/{email}")]
        public async Task<IActionResult> FindUser(string email)
        {
            var result=await _userService.FindUser(email);
            if (result != null)
                return Ok( await _defaultJson.DeffPatternAnswer(200, "Found", result));
            else
                return BadRequest( await _defaultJson.DeffPatternAnswer(400, "Not Found") );
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
                    return Accepted(await _defaultJson.DeffPatternAnswer(202,"Accepted", user));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(await _defaultJson.DeffPatternAnswer(400,"Wasn't delete", errors: ModelState));
                }
            }

            else
            {
                return BadRequest(await _defaultJson.DeffPatternAnswer(400,"wasn't found user"));
            }
        }


        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(IdentityRole roleName)
        {
            var  result=await _userService.CreateRole(roleName.Name);

            if (result.Succeeded)
                return Created( HttpContext.Request.Host.Value,await _defaultJson.DeffPatternAnswer(201, "Created", result));
            else
                return BadRequest( await _defaultJson.DeffPatternAnswer(400, "Wasn't add role", errors: result.Errors));
        }

        [HttpDelete]
        [Route("DeleteRole/{name}")]
        public async Task<IActionResult> DeleteRole(string name)
        {
            var  result=await _userService.DeleteRole(name);
            if (result.Succeeded)
                return Ok( await _defaultJson.DeffPatternAnswer(202, "Deleted"));
            else
                return BadRequest( await _defaultJson.DeffPatternAnswer(400, "Wasn't delete", errors: result.Errors));
        }

        [HttpGet]
        [Route("FindRole/{name}")]
        public async Task<IActionResult> FindRole(string name)
        {
            var result=await _userService.FindRole(name);
            if (result != null)
                return Ok( await _defaultJson.DeffPatternAnswer(200, "Found", result));
            else return BadRequest( await _defaultJson.DeffPatternAnswer(204, "Not Found"));
        }
        
        [HttpPost]
        [Route("AddToRole")]
        public async Task<IActionResult> AddToRole(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AddToRole(role);

                if (result.Succeeded)
                {
                    return Created( HttpContext.Request.Host.Value ,await _defaultJson.DeffPatternAnswer(201, "Added"));
                }
                else
                {
                    return BadRequest( await _defaultJson.DeffPatternAnswer(400, "Wasn't add", errors: result.Errors));
                }
            }
            else return BadRequest(await _defaultJson.DeffPatternAnswer(400,errors: ModelState) );
        }

        [HttpPost]
        [Route("RemoveFromRole")]
        public async Task<IActionResult> RemoveRole(RoleViewModel role)
        {
            var result = await _userService.RemoveFromRole(role);
            if (result.Succeeded)
                return Accepted(await _defaultJson.DeffPatternAnswer(202,"Accepted"));
            else
                return BadRequest( await _defaultJson.DeffPatternAnswer(400, "wasn't delete" ,errors:result.Errors ));
        }
    }
}