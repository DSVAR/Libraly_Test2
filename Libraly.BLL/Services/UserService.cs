using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.UserDTO;
using Libraly.Data.Entities;
using Libraly.Data.Interfaces;
using Libraly.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Libraly.BLL.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

       public UserService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
       {
           _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public  IQueryable<User> GetUsers()
        {
            return  _userManager.Users.AsQueryable();//await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityResult> Create(RegisterViewModel registerView)
        {
            var user = _mapper.Map<User>(registerView);
            return await _userManager.CreateAsync(user);
        }
        
        public Task<User> FindUser(string name)
        {
            throw new System.NotImplementedException();
        }
        
        public async Task<IdentityResult> DeleteUser(User user)
        {
            return await _userManager.DeleteAsync(user);
        }
        
        public async Task<IdentityResult> ChangePassword(User user,ChangePasswordViewModel passwordViewModel)
        {
            return await _userManager.ChangePasswordAsync(user, passwordViewModel.OldPassword, passwordViewModel.NewPassword);
        }
        
        public Task<SignInResult> SignIn(User user, bool remember)
        {
            throw new System.NotImplementedException();
        }
        
        public Task LogOut()
        {
            throw new System.NotImplementedException();
        }
        
        public async Task<IdentityResult> CreateRole(string name)
        {
            return await _roleManager.CreateAsync(new IdentityRole(name));
        }
        
        public async Task<IdentityResult> AddRoleForUser(User user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }
        
        public async Task<IdentityResult> DeleteRole(string name)
        {
            return await _roleManager.DeleteAsync(new IdentityRole(name));
        }
        
        public async Task<IdentityRole> FindRole(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }
        
    }
}