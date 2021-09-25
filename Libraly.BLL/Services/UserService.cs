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
using Microsoft.EntityFrameworkCore;

namespace Libraly.BLL.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IUserService _userServiceImplementation;

        public UserService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
       {
           _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<User>>GetUsers()
        {
            return  _userManager.Users;//await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityResult> Create(RegisterViewModel registerView)
        {
            var user = _mapper.Map<UserViewModel>(registerView);
            return await _userManager.CreateAsync(user);
        }
        
        public Task<User> FindUser(string email)
        {
            return _userManager.FindByEmailAsync(email);
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
            var role = await _roleManager.FindByNameAsync(name);
            return await _roleManager.DeleteAsync(role);
        }
        
        public async Task<IdentityRole> FindRole(string name)
        {
            
            return await _roleManager.FindByNameAsync(name);
        }

        public async Task<IdentityResult> AddToRole(UserViewModel user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<bool> IsInRole(UserViewModel user, string role)
        {
            return  await _userManager.IsInRoleAsync(user, role);
        }
    }
}